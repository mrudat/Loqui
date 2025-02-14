using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Loqui.Generation
{
    public class ListType : ContainerType
    {
        public override string TypeName(bool getter, bool needsCovariance = false) => ListTypeName(getter, internalInterface: true);
        public override bool CopyNeedsTryCatch => true;
        public override bool HasDefault => false;

        public virtual string ListTypeName(bool getter, bool internalInterface)
        {
            string itemTypeName = this.ItemTypeName(getter: getter);
            if (this.SubTypeGeneration is LoquiType loqui)
            {
                itemTypeName = loqui.TypeNameInternal(getter: getter, internalInterface: internalInterface);
            }
            if (this.ReadOnly || getter)
            {
                if (this.Notifying)
                {
                    return $"IObservableList<{itemTypeName}{SubTypeGeneration.NullChar}>";
                }
                else
                {
                    return $"IReadOnlyList<{itemTypeName}{SubTypeGeneration.NullChar}>";
                }
            }
            else
            {
                if (this.Notifying)
                {
                    return $"SourceList<{itemTypeName}{SubTypeGeneration.NullChar}>";
                }
                else if (this.SubTypeGeneration is ByteArrayType)
                {
                    return $"SliceList<byte>";
                }
                else
                {
                    return $"ExtendedList<{itemTypeName}{SubTypeGeneration.NullChar}>";
                }
            }
        }

        public override void GenerateForClass(FileGeneration fg)
        {
            fg.AppendLine($"[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
            fg.AppendLine($"private {this.TypeName(getter: false)}{this.NullChar} _{this.Name}{(this.Nullable ? null : $" = {GetActualItemClass(ctor: true)}")};");
            fg.AppendLine($"public {this.TypeName(getter: false)}{this.NullChar} {this.Name}");
            using (new BraceWrapper(fg))
            {
                fg.AppendLine($"get => this._{this.Name};");
                fg.AppendLine($"{((ReadOnly || !this.Nullable) ? "protected " : string.Empty)}set => this._{this.Name} = value;");
            }
            GenerateInterfaceMembers(fg, $"_{this.Name}");
        }

        protected virtual string GetActualItemClass(bool ctor = false)
        {
            if (this.NotifyingType == NotifyingType.ReactiveUI)
            {
                return $"new SourceList<{ItemTypeName(getter: false)}>{(ctor ? "()" : null)}";
            }
            else if (this.SubTypeGeneration is ByteArrayType)
            {
                return $"new SliceList<byte>{(ctor ? "()" : null)}";
            }
            else
            {
                return $"new ExtendedList<{ItemTypeName(getter: false)}>{(ctor ? "()" : null)}";
            }
        }

        public void GenerateInterfaceMembers(FileGeneration fg, string member)
        {
            using (new RegionWrapper(fg, "Interface Members"))
            {
                fg.AppendLine($"[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                fg.AppendLine($"{ListTypeName(getter: true, internalInterface: true)}{this.NullChar} {this.ObjectGen.Interface(getter: true, internalInterface: this.InternalGetInterface)}.{this.Name} => {member};");
            }
        }

        public override void GenerateForInterface(FileGeneration fg, bool getter, bool internalInterface)
        {
            if (!ApplicableInterfaceField(getter: getter, internalInterface: internalInterface)) return;
            if (getter)
            {
                fg.AppendLine($"{ListTypeName(getter: true, internalInterface: true)}{this.NullChar} {this.Name} {{ get; }}");
            }
            else
            {
                if (!this.ReadOnly)
                {
                    fg.AppendLine($"new {ListTypeName(getter: false, internalInterface: true)}{this.NullChar} {this.Name} {{ get; {(this.Nullable ? "set; " : null)}}}");
                }
            }
        }

        public override string NullableAccessor(bool getter, Accessor accessor = null)
        {
            if (accessor == null)
            {
                return $"({this.Name} != null)";
            }
            else
            {
                return $"({accessor} != null)";
            }
        }

        public override void GenerateGetNth(FileGeneration fg, Accessor identifier)
        {
            fg.AppendLine($"return {identifier.Access};");
        }

        public override string SkipCheck(Accessor copyMaskAccessor, bool deepCopy)
        {
            var loqui = this.SubTypeGeneration as LoquiType;
            if (!deepCopy
                && loqui != null
                && loqui.SupportsMask(MaskType.Copy))
            {
                return $"{copyMaskAccessor}?.{this.Name}.Overall != {nameof(CopyOption)}.{nameof(CopyOption.Skip)}";
            }
            else if (deepCopy
                && loqui != null
                && loqui.SupportsMask(MaskType.Translation))
            {
                return $"{copyMaskAccessor}?.{this.Name}.Overall ?? true";
            }
            else
            {
                if (deepCopy)
                {
                    return $"{copyMaskAccessor}?.{this.Name} ?? true";
                }
                else
                {
                    return $"{copyMaskAccessor}?.{this.Name} != {nameof(CopyOption)}.{nameof(CopyOption.Skip)}";
                }
            }
        }

        public override void GenerateForCopy(
            FileGeneration fg,
            Accessor accessor,
            Accessor rhs,
            Accessor copyMaskAccessor,
            bool protectedMembers,
            bool deepCopy)
        {
            void GenerateSet()
            {
                if (this.isLoquiSingle)
                {
                    if (deepCopy)
                    {
                        LoquiType loqui = this.SubTypeGeneration as LoquiType;
                        WrapSet(fg, accessor, (f) =>
                        {
                            f.AppendLine(rhs.ToString());
                            f.AppendLine(".Select(r =>");
                            using (new BraceWrapper(f) { AppendParenthesis = true })
                            {
                                loqui.GenerateTypicalMakeCopy(
                                    f,
                                    retAccessor: $"return ",
                                    rhsAccessor: Accessor.FromType(loqui, "r"),
                                    copyMaskAccessor: copyMaskAccessor,
                                    deepCopy: deepCopy,
                                    doTranslationMask: false);
                            }
                        });
                    }
                    else
                    {
                        LoquiType loqui = this.SubTypeGeneration as LoquiType;
                        using (var args = new ArgsWrapper(fg,
                            $"{accessor}.SetTo<{this.SubTypeGeneration.TypeName(getter: false)}, {this.SubTypeGeneration.TypeName(getter: false)}>"))
                        {
                            args.Add($"items: {rhs}");
                            args.Add((gen) =>
                            {
                                gen.AppendLine("converter: (r) =>");
                                using (new BraceWrapper(gen))
                                {
                                    var supportsCopy = loqui.SupportsMask(MaskType.Copy);
                                    var accessorStr = $"copyMask?.{this.Name}{(supportsCopy ? ".Overall" : string.Empty)}";
                                    gen.AppendLine($"switch ({accessorStr} ?? {nameof(CopyOption)}.{nameof(CopyOption.Reference)})");
                                    using (new BraceWrapper(gen))
                                    {
                                        gen.AppendLine($"case {nameof(CopyOption)}.{nameof(CopyOption.Reference)}:");
                                        using (new DepthWrapper(gen))
                                        {
                                            gen.AppendLine($"return ({loqui.TypeName()})r;");
                                        }
                                        gen.AppendLine($"case {nameof(CopyOption)}.{nameof(CopyOption.MakeCopy)}:");
                                        using (new DepthWrapper(gen))
                                        {
                                            loqui.GenerateTypicalMakeCopy(
                                                gen,
                                                retAccessor: $"return ",
                                                rhsAccessor: new Accessor("r"),
                                                copyMaskAccessor: copyMaskAccessor,
                                                deepCopy: deepCopy,
                                                doTranslationMask: false);
                                        }
                                        gen.AppendLine($"default:");
                                        using (new DepthWrapper(gen))
                                        {
                                            gen.AppendLine($"throw new NotImplementedException($\"Unknown {nameof(CopyOption)} {{{accessorStr}}}. Cannot execute copy.\");");
                                        }
                                    }
                                }
                            });
                        }
                    }
                }
                else
                {
                    WrapSet(fg, accessor, (f) =>
                    {
                        f.AppendLine($"rhs.{this.Name}");
                        this.SubTypeGeneration.GenerateCopySetToConverter(f);
                    });
                }
            }

            if (!this.AlwaysCopy)
            {
                fg.AppendLine($"if ({(deepCopy ? this.GetTranslationIfAccessor(copyMaskAccessor) : this.SkipCheck(copyMaskAccessor, deepCopy))})");
            }
            using (new BraceWrapper(fg, doIt: !AlwaysCopy))
            {
                MaskGenerationUtility.WrapErrorFieldIndexPush(
                    fg,
                    () =>
                    {
                        if (this.Nullable)
                        {
                            fg.AppendLine($"if ({this.NullableAccessor(getter: false, rhs)})");
                            using (new BraceWrapper(fg))
                            {
                                GenerateSet();
                            }
                            fg.AppendLine("else");
                            using (new BraceWrapper(fg))
                            {
                                GenerateClear(fg, accessor);
                            }
                        }
                        else
                        {
                            GenerateSet();
                        }
                    },
                    errorMaskAccessor: "errorMask",
                    indexAccessor: this.HasIndex ? this.IndexEnumInt : default(Accessor),
                    doIt: this.CopyNeedsTryCatch);
            }
        }

        public override void GenerateSetNth(FileGeneration fg, Accessor accessor, Accessor rhs, bool internalUse)
        {
            fg.AppendLine($"{accessor}.SetTo({rhs});");
            fg.AppendLine($"break;");
        }

        public void WrapSet(FileGeneration fg, Accessor accessor, Action<FileGeneration> a)
        {
            if (this.Nullable)
            {
                fg.AppendLine($"{accessor} = ");
                using (new DepthWrapper(fg))
                {
                    a(fg);
                    fg.AppendLine($".ToExtendedList<{this.SubTypeGeneration.TypeName(getter: false, needsCovariance: true)}>();");
                }
            }
            else
            {
                using (var args = new ArgsWrapper(fg,
                    $"{accessor}.SetTo"))
                {
                    args.Add(subFg => a(subFg));
                }
            }
        }

        public override void GenerateClear(FileGeneration fg, Accessor accessor)
        {
            if (this.Nullable)
            {
                fg.AppendLine($"{accessor} = null;");
            }
            else
            {
                fg.AppendLine($"{accessor}.Clear();");
            }
        }

        public override void GenerateToString(FileGeneration fg, string name, Accessor accessor, string fgAccessor)
        {
            fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"{name} =>\");");
            fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"[\");");
            fg.AppendLine($"using (new DepthWrapper({fgAccessor}))");
            using (new BraceWrapper(fg))
            {
                fg.AppendLine($"foreach (var subItem in {accessor.Access})");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"[\");");
                    fg.AppendLine($"using (new DepthWrapper({fgAccessor}))");
                    using (new BraceWrapper(fg))
                    {
                        this.SubTypeGeneration.GenerateToString(fg, "Item", new Accessor("subItem"), fgAccessor);
                    }
                    fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"]\");");
                }
            }
            fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"]\");");
        }

        public override void GenerateForNullableCheck(FileGeneration fg, Accessor accessor, string checkMaskAccessor)
        {
            if (this.Nullable)
            {
                fg.AppendLine($"if ({checkMaskAccessor}?.Overall.HasValue ?? false && {checkMaskAccessor}!.Overall.Value != {NullableAccessor(getter: true, accessor: accessor)}) return false;");
            }
        }

        public override string GetDuplicate(Accessor accessor)
        {
            throw new NotImplementedException();
        }

        public override async Task Load(XElement node, bool requireName = true)
        {
            if (node.Name.LocalName == "RefList")
            {
                LoadTypeGenerationFromNode(node, requireName);
                SubTypeGeneration = this.ObjectGen.ProtoGen.Gen.GetTypeGeneration<LoquiType>();
                SubTypeGeneration.SetObjectGeneration(this.ObjectGen, setDefaults: false);
                await SubTypeGeneration.Load(node, false);
                SubTypeGeneration.Name = null;
                isLoquiSingle = SubTypeGeneration as LoquiType != null;
            }
            else
            {
                await base.Load(node, requireName);
            }
        }
    }
}
