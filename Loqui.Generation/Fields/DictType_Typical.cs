﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Loqui.Generation
{
    public class DictType_Typical : TypeGeneration, IDictType
    {
        public TypeGeneration ValueTypeGen;
        TypeGeneration IDictType.ValueTypeGen => this.ValueTypeGen;
        protected bool ValueIsLoqui;
        public TypeGeneration KeyTypeGen;
        TypeGeneration IDictType.KeyTypeGen => this.KeyTypeGen;
        protected bool KeyIsLoqui;
        public DictMode Mode => DictMode.KeyValue;
        public bool BothAreLoqui => KeyIsLoqui && ValueIsLoqui;

        public override string Property => $"{this.Name}";
        public override string ProtectedName => $"{this.ProtectedProperty}";
        public override bool CopyNeedsTryCatch => true;
        public override bool IsEnumerable => true;
        public override string SkipCheck(string copyMaskAccessor)
        {
            if (KeyTypeGen is LoquiType
                || ValueTypeGen is LoquiType)
            {
                return $"{copyMaskAccessor}?.{this.Name}.Overall ?? true";
            }
            else
            {
                return $"{copyMaskAccessor}?.{this.Name} ?? true";
            }
        }

        public override string TypeName => $"NotifyingDictionary<{KeyTypeGen.TypeName}, {ValueTypeGen.TypeName}>";

        public string TypeTuple => $"{KeyTypeGen.TypeName}, {ValueTypeGen.TypeName}";

        public string GetterTypeName => (this.ValueIsLoqui ? $"I{TypeName}Getter" : TypeName);

        public override async Task Load(XElement node, bool requireName = true)
        {
            await base.Load(node, requireName);

            var keyNode = node.Element(XName.Get("Key", LoquiGenerator.Namespace));
            if (keyNode == null)
            {
                throw new ArgumentException("Dict had no key element.");
            }

            var keyTypeGen = await ObjectGen.LoadField(
                keyNode.Elements().FirstOrDefault(),
                requireName: false,
                setDefaults: false);
            if (keyTypeGen.Succeeded)
            {
                this.KeyTypeGen = keyTypeGen.Value;
                KeyIsLoqui = keyTypeGen.Value as LoquiType != null;
            }
            else
            {
                throw new NotImplementedException();
            }

            var valNode = node.Element(XName.Get("Value", LoquiGenerator.Namespace));
            if (valNode == null)
            {
                throw new ArgumentException("Dict had no value element.");
            }

            var valueTypeGen = await ObjectGen.LoadField(
                valNode.Elements().FirstOrDefault(),
                requireName: false,
                setDefaults: false);
            if (valueTypeGen.Succeeded)
            {
                this.ValueTypeGen = valueTypeGen.Value;
                ValueIsLoqui = valueTypeGen.Value is LoquiType;
            }
            else
            {
                throw new NotImplementedException();
            }

            if (keyTypeGen.Value is ContainerType
                || keyTypeGen.Value is DictType)
            {
                throw new NotImplementedException();
            }
            if (valueTypeGen.Value is ContainerType
                || valueTypeGen.Value is DictType)
            {
                throw new NotImplementedException();
            }
        }

        public void AddMaskException(FileGeneration fg, string errorMaskMemberAccessor, string exception, bool key)
        {
            LoquiType keyLoquiType = this.KeyTypeGen as LoquiType;
            LoquiType valueLoquiType = this.ValueTypeGen as LoquiType;
            var item2 = $"KeyValuePair<{(keyLoquiType == null ? "Exception" : keyLoquiType.TargetObjectGeneration.GetMaskString("Exception"))}, {(valueLoquiType == null ? "Exception" : valueLoquiType.TargetObjectGeneration.GetMaskString("Exception"))}>";

            fg.AppendLine($"{errorMaskMemberAccessor}?.{this.Name}.Value.Add(new {item2}({(key ? exception : "null")}, {(key ? "null" : exception)}));");
        }

        public override void GenerateSetNthHasBeenSet(FileGeneration fg, string identifier, string onIdentifier)
        {
            if (!this.Protected)
            {
                fg.AppendLine($"{identifier}.{this.GetName(internalUse: false)}.HasBeenSet = {onIdentifier};");
            }
            fg.AppendLine("break;");
        }

        public override void GenerateUnsetNth(FileGeneration fg, string identifier, string cmdsAccessor)
        {
            if (!this.Protected)
            {
                fg.AppendLine($"{identifier}.{this.GetName(false)}.Unset({cmdsAccessor});");
            }
            fg.AppendLine("break;");
        }

        public override string GetName(bool internalUse, bool property = true)
        {
            if (internalUse)
            {
                return $"_{this.Name}";
            }
            else
            {
                return this.Name;
            }
        }

        public override void GenerateForClass(FileGeneration fg)
        {
            if (this.ValueTypeGen is WildcardType wild)
            {
                fg.AppendLine($"private readonly INotifyingDictionary<{TypeTuple}> _{this.Name} = new NotifyingDictionary<{TypeTuple}>(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine("valConv: (o) => WildcardLink.Validate(o));");
                }
            }
            else
            {
                fg.AppendLine($"private readonly INotifyingDictionary<{TypeTuple}> _{this.Name} = new NotifyingDictionary<{TypeTuple}>();");
            }
            fg.AppendLine($"public INotifyingDictionary<{TypeTuple}> {this.Name} {{ get {{ return _{this.Name}; }} }}");

            var member = "_" + this.Name;
            using (new RegionWrapper(fg, "Interface Members"))
            {
                if (!this.Protected)
                {
                    fg.AppendLine($"INotifyingDictionary{(this.Protected ? "Getter" : string.Empty)}<{this.TypeTuple}> {this.ObjectGen.InterfaceStr}.{this.Name} => {member};");
                }
                fg.AppendLine($"INotifyingDictionaryGetter<{this.TypeTuple}> {this.ObjectGen.Getter_InterfaceStr}.{this.Name} => {member};");
            }
        }

        public override void GenerateForInterface(FileGeneration fg)
        {
            if (!this.Protected)
            {
                fg.AppendLine($"new INotifyingDictionary{(this.Protected ? "Getter" : string.Empty)}<{this.TypeTuple}> {this.Name} {{ get; }}");
            }
        }

        public override void GenerateForGetterInterface(FileGeneration fg)
        {
            fg.AppendLine($"INotifyingDictionaryGetter<{this.TypeTuple}> {this.Name} {{ get; }}");
        }

        public override void GenerateForCopy(
            FileGeneration fg,
            string accessorPrefix,
            string rhsAccessorPrefix,
            string copyMaskAccessor,
            string defaultFallbackAccessor,
            string cmdsAccessor,
            bool protectedMembers)
        {
            if (!this.KeyIsLoqui && !this.ValueIsLoqui)
            {
                using (var args = new ArgsWrapper(fg,
                    $"{accessorPrefix}.{this.Name}.SetToWithDefault"))
                {
                    args.Add($"rhs.{this.Name}");
                    args.Add($"def?.{this.Name}");
                    args.Add($"cmds");
                }
                return;
            }
            using (var args = new ArgsWrapper(fg,
                $"{accessorPrefix}.{this.Name}.SetToWithDefault"))
            {
                args.Add($"rhs.{this.Name}");
                args.Add($"def?.{this.Name}");
                args.Add($"cmds");
                args.Add((gen) =>
                {
                    gen.AppendLine("(k, v, d) =>");
                    using (new BraceWrapper(gen))
                    {
                        if (this.KeyIsLoqui)
                        {
                            gen.AppendLine($"{this.KeyTypeGen.TypeName} key;");
                            gen.AppendLine($"switch ({copyMaskAccessor}?.Specific.{(this.BothAreLoqui ? "Key." : string.Empty)}Type ?? {nameof(RefCopyType)}.{nameof(RefCopyType.Reference)})");
                            using (new BraceWrapper(gen))
                            {
                                gen.AppendLine($"case {nameof(RefCopyType)}.{nameof(RefCopyType.Reference)}:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"key = k;");
                                    gen.AppendLine($"break;");
                                }
                                gen.AppendLine($"case {nameof(RefCopyType)}.{nameof(RefCopyType.MakeCopy)}:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"key = k.Copy(copyMask: {copyMaskAccessor}?.Specific.{(this.BothAreLoqui ? "Key." : string.Empty)}Mask);");
                                    gen.AppendLine($"break;");
                                }
                                gen.AppendLine($"default:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"throw new NotImplementedException($\"Unknown {nameof(RefCopyType)} {{copyMask?.{this.Name}.Overall}}. Cannot execute copy.\");");
                                }
                            }
                        }
                        if (this.ValueIsLoqui)
                        {
                            gen.AppendLine($"{this.ValueTypeGen.TypeName} val;");
                            gen.AppendLine($"switch ({copyMaskAccessor}?.Specific.{(this.BothAreLoqui ? "Value." : string.Empty)}Type ?? {nameof(RefCopyType)}.{nameof(RefCopyType.Reference)})");
                            using (new BraceWrapper(gen))
                            {
                                gen.AppendLine($"case {nameof(RefCopyType)}.{nameof(RefCopyType.Reference)}:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"val = v;");
                                    gen.AppendLine($"break;");
                                }
                                gen.AppendLine($"case {nameof(RefCopyType)}.{nameof(RefCopyType.MakeCopy)}:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"val = v.Copy({copyMaskAccessor}?.Specific.{(this.BothAreLoqui ? "Value." : string.Empty)}Mask, d);");
                                    gen.AppendLine($"break;");
                                }
                                gen.AppendLine($"default:");
                                using (new DepthWrapper(gen))
                                {
                                    gen.AppendLine($"throw new NotImplementedException($\"Unknown {nameof(RefCopyType)} {{copyMask?.{this.Name}.Overall}}. Cannot execute copy.\");");
                                }
                            }
                        }

                        gen.AppendLine($"return new KeyValuePair<{this.KeyTypeGen.TypeName}, {this.ValueTypeGen.TypeName}>({(this.KeyIsLoqui ? "key" : "k")}, {(this.ValueIsLoqui ? "val" : "v")});");
                    }
                });
            }
        }

        private void GenerateCopy(FileGeneration fg, string accessorPrefix, string rhsAccessorPrefix, string cmdAccessor)
        {
            fg.AppendLine($"{accessorPrefix}.{this.Name}.SetTo(");
            using (new DepthWrapper(fg))
            {
                fg.AppendLine($"{rhsAccessorPrefix}.{this.Name}.Select(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine($"(i) => new KeyValuePair<{this.KeyTypeGen.TypeName}, {this.ValueTypeGen.TypeName}>(");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"i.Key{(this.KeyIsLoqui ? ".CopyFieldsFrom()" : string.Empty) },");
                        fg.AppendLine($"i.Value{(this.ValueIsLoqui ? ".CopyFieldsFrom()" : string.Empty)})),");
                    }
                }
                fg.AppendLine($"{cmdAccessor});");
            }
        }

        public override void GenerateSetNth(FileGeneration fg, string accessorPrefix, string rhsAccessorPrefix, string cmdsAccessor, bool internalUse)
        {
            fg.AppendLine($"{accessorPrefix}.{this.Name}.SetTo(");
            using (new DepthWrapper(fg))
            {
                fg.AppendLine($"({rhsAccessorPrefix}).Select(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine($"(i) => new KeyValuePair<{this.KeyTypeGen.TypeName}, {this.ValueTypeGen.TypeName}>(");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"i.Key{(this.KeyIsLoqui ? ".Copy()" : string.Empty) },");
                        fg.AppendLine($"i.Value{(this.ValueIsLoqui ? ".Copy()" : string.Empty)})),");
                    }
                }
                fg.AppendLine($"{cmdsAccessor});");
            }
            fg.AppendLine($"break;");
        }

        public override void GenerateGetNth(FileGeneration fg, string identifier)
        {
            fg.AppendLine($"return {identifier}.{this.Name};");
        }

        public override void GenerateClear(FileGeneration fg, string accessorPrefix, string cmdAccessor)
        {
            fg.AppendLine($"{accessorPrefix}.{this.Name}.Unset({cmdAccessor}.ToUnsetParams());");
        }

        public override string GenerateACopy(string rhsAccessor)
        {
            throw new NotImplementedException();
        }

        public override void GenerateForEquals(FileGeneration fg, string rhsAccessor)
        {
            fg.AppendLine($"if (!{this.Name}.SequenceEqual({rhsAccessor}.{this.Name})) return false;");
        }

        public override void GenerateForEqualsMask(FileGeneration fg, Accessor accessor, Accessor rhsAccessor, string retAccessor)
        {
            if (this.Bare)
            {
                this.GenerateForEqualsMaskCheck(fg, $"item.{this.Name}", $"rhs.{this.Name}", $"ret.{this.Name}");
            }
            else
            {
                fg.AppendLine($"if (item.{this.HasBeenSetAccessor} == rhs.{this.HasBeenSetAccessor})");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"if (item.{this.HasBeenSetAccessor})");
                    using (new BraceWrapper(fg))
                    {
                        this.GenerateForEqualsMaskCheck(fg, $"item.{this.Name}", $"rhs.{this.Name}", $"ret.{this.Name}");
                    }
                    fg.AppendLine($"else");
                    using (new BraceWrapper(fg))
                    {
                        this.GenerateForEqualsMask(fg, $"ret.{this.Name}", true);
                    }
                }
                fg.AppendLine($"else");
                using (new BraceWrapper(fg))
                {
                    this.GenerateForEqualsMask(fg, $"ret.{this.Name}", false);
                }
            }
        }

        public void GenerateForEqualsMaskCheck(FileGeneration fg, string accessor, string rhsAccessor, string retAccessor)
        {
            fg.AppendLine($"{retAccessor} = new {DictMaskFieldGeneration.GetMaskString(this, "bool")}();");
            LoquiType keyLoqui = KeyTypeGen as LoquiType;
            LoquiType valLoqui = ValueTypeGen as LoquiType;
            if (keyLoqui != null
                && valLoqui != null)
            {
                var keyMaskStr = $"MaskItem<bool, {keyLoqui.TargetObjectGeneration.GetMaskString("bool")}>";
                var valMaskStr = $"MaskItem<bool, {valLoqui.TargetObjectGeneration.GetMaskString("bool")}>";
                var maskStr = $"KeyValuePair<{keyMaskStr}, {valMaskStr}>";
                fg.AppendLine($"{retAccessor}.Specific = {accessor}.SelectAgainst<KeyValuePair<{this.TypeTuple}>, {maskStr}>({rhsAccessor}, ((l, r) =>");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"{keyMaskStr} keyItemRet;");
                    fg.AppendLine($"{valMaskStr} valItemRet;");
                    keyLoqui.GenerateForEqualsMask(fg, new Accessor("l.Key"), new Accessor("r.Key"), "keyItemRet");
                    valLoqui.GenerateForEqualsMask(fg, new Accessor("l.Value"), new Accessor("r.Value"), "valItemRet");
                    fg.AppendLine($"return new {maskStr}(keyItemRet, valItemRet);");
                }
                fg.AppendLine($"), out {retAccessor}.Overall);");
                fg.AppendLine($"{retAccessor}.Overall = {retAccessor}.Overall && {retAccessor}.Specific.All((b) => b.Key.Overall && b.Value.Overall );");
            }
            else if (keyLoqui != null)
            {
                var keyMaskStr = $"MaskItem<bool, {keyLoqui.TargetObjectGeneration.GetMaskString("bool")}>";
                var maskStr = $"KeyValuePair<{keyMaskStr}, bool>";
                fg.AppendLine($"{retAccessor}.Specific = {accessor}.SelectAgainst<KeyValuePair<{this.TypeTuple}>, {maskStr}>({rhsAccessor}, ((l, r) =>");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"{keyMaskStr} keyItemRet;");
                    fg.AppendLine($"bool valItemRet = object.Equals(l.Value, r.Value);");
                    keyLoqui.GenerateForEqualsMask(fg, new Accessor("l.Key"), new Accessor("r.Key"), "keyItemRet");
                    fg.AppendLine($"return new {maskStr}(keyItemRet, valItemRet);");
                }
                fg.AppendLine($"), out {retAccessor}.Overall);");
                fg.AppendLine($"{retAccessor}.Overall = {retAccessor}.Overall && {retAccessor}.Specific.All((b) => b.Key.Overall && b.Value);");
            }
            else if (valLoqui != null)
            {
                var valMaskStr = $"MaskItem<bool, {valLoqui.TargetObjectGeneration.GetMaskString("bool")}>";
                var maskStr = $"KeyValuePair<bool, {valMaskStr}>";
                fg.AppendLine($"{retAccessor}.Specific = {accessor}.SelectAgainst<KeyValuePair<{this.TypeTuple}>, {maskStr}>({rhsAccessor}, ((l, r) =>");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"bool keyItemRet = object.Equals(l.Key, r.Key);");
                    fg.AppendLine($"{valMaskStr} valItemRet;");
                    valLoqui.GenerateForEqualsMask(fg, new Accessor("l.Value"), new Accessor("r.Value"), "valItemRet");
                    fg.AppendLine($"return new {maskStr}(keyItemRet, valItemRet);");
                }
                fg.AppendLine($"), out {retAccessor}.Overall);");
                fg.AppendLine($"{retAccessor}.Overall = {retAccessor}.Overall && {retAccessor}.Specific.All((b) => b.Key && b.Value.Overall);");
            }
            else
            {
                fg.AppendLine($"{retAccessor}.Specific = {accessor}.SelectAgainst<KeyValuePair<{this.TypeTuple}>, KeyValuePair<bool, bool>>({rhsAccessor}, ((l, r) => new KeyValuePair<bool, bool>(object.Equals(l.Key, r.Key), object.Equals(l.Value, r.Value))), out {retAccessor}.Overall);");
                fg.AppendLine($"{retAccessor}.Overall = {retAccessor}.Overall && {retAccessor}.Specific.All((b) => b.Key && b.Value);");
            }
        }

        public void GenerateForEqualsMask(FileGeneration fg, string retAccessor, bool on)
        {
            fg.AppendLine($"{retAccessor} = new {DictMaskFieldGeneration.GetMaskString(this, "bool")}();");
            fg.AppendLine($"{retAccessor}.Overall = {(on ? "true" : "false")};");
        }

        public override void GenerateForHash(FileGeneration fg, string hashResultAccessor)
        {
            fg.AppendLine($"{hashResultAccessor} = HashHelper.GetHashCode({this.Name}).CombineHashCode({hashResultAccessor});");
        }

        public override void GenerateToString(FileGeneration fg, string name, string accessor, string fgAccessor)
        {
            fg.AppendLine($"fg.{nameof(FileGeneration.AppendLine)}(\"{name} =>\");");
            fg.AppendLine($"fg.{nameof(FileGeneration.AppendLine)}(\"[\");");
            fg.AppendLine($"using (new DepthWrapper(fg))");
            using (new BraceWrapper(fg))
            {
                fg.AppendLine($"foreach (var subItem in {accessor})");
                using (new BraceWrapper(fg))
                {
                    fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"[\");");
                    fg.AppendLine($"using (new DepthWrapper({fgAccessor}))");
                    using (new BraceWrapper(fg))
                    {
                        this.KeyTypeGen.GenerateToString(fg, "Key", "subItem.Key", fgAccessor);
                        this.ValueTypeGen.GenerateToString(fg, "Value", "subItem.Value", fgAccessor);
                    }
                    fg.AppendLine($"{fgAccessor}.{nameof(FileGeneration.AppendLine)}(\"]\");");
                }
            }
            fg.AppendLine($"fg.{nameof(FileGeneration.AppendLine)}(\"]\");");
        }

        public override void GenerateForHasBeenSetCheck(FileGeneration fg, string accessor, string checkMaskAccessor)
        {
            fg.AppendLine($"if ({checkMaskAccessor}.Overall.HasValue && {checkMaskAccessor}.Overall.Value != {accessor}.HasBeenSet) return false;");
        }

        public override void GenerateForHasBeenSetMaskGetter(FileGeneration fg, string accessor, string retAccessor)
        {
            if (!this.KeyIsLoqui && !this.ValueIsLoqui)
            {
                fg.AppendLine($"{retAccessor} = new MaskItem<bool, IEnumerable<KeyValuePair<bool, bool>>>({accessor}.HasBeenSet, null);");
                return;
            }
            LoquiType keyLoqui = this.KeyTypeGen as LoquiType;
            LoquiType valLoqui = this.ValueTypeGen as LoquiType;
            if (keyLoqui != null && valLoqui != null)
            {
                fg.AppendLine($"{retAccessor} = new {DictMaskFieldGeneration.GetMaskString(this, "bool")}(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine($"{accessor}.HasBeenSet, {accessor}.Select((i) => new KeyValuePair<MaskItem<bool, {keyLoqui.GetMaskString("bool")}>, MaskItem<bool, {valLoqui.GetMaskString("bool")}>>(");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"new MaskItem<bool, {keyLoqui.GetMaskString("bool")}>(true, i.Key.GetHasBeenSetMask()),");
                        fg.AppendLine($"new MaskItem<bool, {valLoqui.GetMaskString("bool")}>(true, i.Value.GetHasBeenSetMask()))));");
                    }
                }
            }
            else if (keyLoqui != null)
            {
                fg.AppendLine($"{retAccessor} = new {DictMaskFieldGeneration.GetMaskString(this, "bool")}(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine($"{accessor}.HasBeenSet, {accessor}.Select((i) => new KeyValuePair<MaskItem<bool, {keyLoqui.GetMaskString("bool")}>, bool>(");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"new MaskItem<bool, {keyLoqui.GetMaskString("bool")}>(true, i.Key.GetHasBeenSetMask()),");
                        fg.AppendLine($"true)));");
                    }
                }
            }
            else
            {
                fg.AppendLine($"{retAccessor} = new {DictMaskFieldGeneration.GetMaskString(this, "bool")}(");
                using (new DepthWrapper(fg))
                {
                    fg.AppendLine($"{accessor}.HasBeenSet, {accessor}.Select((i) => new KeyValuePair<bool, MaskItem<bool, {valLoqui.GetMaskString("bool")}>>(");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"true,");
                        fg.AppendLine($"new MaskItem<bool, {valLoqui.GetMaskString("bool")}>(true, i.Value.GetHasBeenSetMask()))));");
                    }
                }
            }
        }

        public override bool IsNullable()
        {
            return false;
        }
    }
}
