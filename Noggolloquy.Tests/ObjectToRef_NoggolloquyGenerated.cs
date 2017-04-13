/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Noggolloquy.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noggolloquy;
using Noggog;
using Noggog.Notifying;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Noggolloquy.Xml;

namespace Noggolloquy.Tests
{
    #region Class
    public partial class ObjectToRef : IObjectToRef, INoggolloquySerializer, IEquatable<ObjectToRef>
    {
        public ObjectToRef()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #region KeyField
        protected readonly INotifyingItem<Int32> _KeyField = new NotifyingItem<Int32>(
            default(Int32),
            markAsSet: false
        );
        public INotifyingItem<Int32> KeyField_Property => _KeyField;
        public Int32 KeyField { get { return _KeyField.Value; } set { _KeyField.Value = value; } }
        INotifyingItem<Int32> IObjectToRef.KeyField_Property => this.KeyField_Property;
        INotifyingItemGetter<Int32> IObjectToRefGetter.KeyField_Property => this.KeyField_Property;
        #endregion

        #region SomeField
        protected readonly INotifyingItem<Boolean> _SomeField = new NotifyingItem<Boolean>(
            default(Boolean),
            markAsSet: false
        );
        public INotifyingItem<Boolean> SomeField_Property => _SomeField;
        public Boolean SomeField { get { return _SomeField.Value; } set { _SomeField.Value = value; } }
        INotifyingItem<Boolean> IObjectToRef.SomeField_Property => this.SomeField_Property;
        INotifyingItemGetter<Boolean> IObjectToRefGetter.SomeField_Property => this.SomeField_Property;
        #endregion


        #region Noggolloquy Getter Interface

        public static string NoggolloquyName => "ObjectToRef";
        string INoggolloquyObjectGetter.NoggolloquyName => "ObjectToRef";
        public static string NoggolloquyFullName => "Noggolloquy.Tests.ObjectToRef";
        string INoggolloquyObjectGetter.NoggolloquyFullName => "Noggolloquy.Tests.ObjectToRef";
        public static ProtocolKey Noggolloquy_ProtocolKey_Static => new ProtocolKey(1);
        public ProtocolKey Noggolloquy_ProtocolKey => Noggolloquy_ProtocolKey_Static;
        public static ProtocolDefinition Noggolloquy_ProtocolDefinition_Static => new ProtocolDefinition(
            key: Noggolloquy_ProtocolKey_Static,
            nickname: "NoggolloquyTests");
        public ProtocolDefinition Noggolloquy_ProtocolDefinition => Noggolloquy_ProtocolDefinition_Static;
        public static ObjectKey Noggolloquy_ObjectKey_Static => new ObjectKey(protocolKey: Noggolloquy_ProtocolKey_Static, msgID: 3, version: 0);
        public ObjectKey Noggolloquy_ObjectKey => Noggolloquy_ObjectKey_Static;
        public int FieldCount => 2;

        public string Noggolloquy_GUID => "39bed53a-0f81-4fdc-8ce4-84563c3125cf";

        public static object GetNthObject(ushort index, IObjectToRefGetter obj)
        {
            switch (index)
            {
                case 0:
                    return obj.KeyField;
                case 1:
                    return obj.SomeField;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(ushort index, IObjectToRef obj)
        {
            switch (index)
            {
                case 0:
                    return obj.KeyField_Property.HasBeenSet;
                case 1:
                    return obj.SomeField_Property.HasBeenSet;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public Type GetNthType(ushort index) => ObjectToRefCommon.GetNthType(index);

        public string GetNthName(ushort index) => ObjectToRefCommon.GetNthName(index);

        public object GetNthObject(ushort index) => ObjectToRefCommon.GetNthObject(index, this);

        public bool GetNthObjectHasBeenSet(ushort index) => ObjectToRefCommon.GetNthObjectHasBeenSet(index, this);

        public ushort? GetNameIndex(StringCaseAgnostic str) => ObjectToRefCommon.GetNameIndex(str);

        public bool IsNthDerivative(ushort index) => ObjectToRefCommon.IsNthDerivative(index);

        public bool IsReadOnly(ushort index) => ObjectToRefCommon.IsReadOnly(index);

        public bool GetNthIsEnumerable(ushort index) => ObjectToRefCommon.GetNthIsEnumerable(index);

        public bool GetNthIsNoggolloquy(ushort index) => ObjectToRefCommon.GetNthIsNoggolloquy(index);

        public bool GetNthIsSingleton(ushort index) => ObjectToRefCommon.GetNthIsSingleton(index);

        public void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds) => ObjectToRefCommon.SetNthObject(this, index, obj, cmds);

        public Type GetMaskType() => typeof(ObjectToRef_Mask<>);

        public Type GetErrorMaskType() => typeof(ObjectToRef_ErrorMask);

        #endregion

        #region Noggolloquy Interface
        public void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            ObjectToRefCommon.SetNthObjectHasBeenSet(index, on, this);
        }

        public void SetNthObjectHasBeenSet_Internal(ushort index, bool on, ObjectToRef obj)
        {
            switch (index)
            {
                case 0:
                    obj._KeyField.SetHasBeenSet(on);
                    break;
                case 1:
                    obj._SomeField.SetHasBeenSet(on);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void CopyFieldsFrom(IObjectToRefGetter rhs, IObjectToRefGetter def = null, NotifyingFireParameters? cmds = null)
        {
            ObjectToRefCommon.CopyFieldsFrom(this, rhs, def, null, cmds);
        }

        public void CopyFieldsFrom(IObjectToRefGetter rhs, out ObjectToRef_ErrorMask errorMask, IObjectToRefGetter def = null, NotifyingFireParameters? cmds = null)
        {
            var retErrorMask = new ObjectToRef_ErrorMask();
            errorMask = retErrorMask;
            ObjectToRefCommon.CopyFieldsFrom(this, rhs, def, retErrorMask, cmds);
        }

        #endregion

        #region To String
        public override string ToString()
        {
            return this.PrintPretty();
        }
        #endregion

        #region Equals and Hash
        public override bool Equals(object obj)
        {
            ObjectToRef rhs = obj as ObjectToRef;
            if (rhs == null) return false;
            return Equals(obj);
        }

        public bool Equals(ObjectToRef rhs)
        {
            if (!object.Equals(this.KeyField, rhs.KeyField)) return false;
            if (!object.Equals(this.SomeField, rhs.SomeField)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return 
            HashHelper.GetHashCode(KeyField)
            .CombineHashCode(HashHelper.GetHashCode(SomeField))
            ;
        }

        #endregion

        #region Set To
        public void SetTo(ObjectToRef rhs, IObjectToRef def = null, NotifyingFireParameters? cmds = null)
        {
            SetTo_Internal(rhs, def, null, cmds);
        }

        public void SetTo(ObjectToRef rhs, IObjectToRef def, out ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            var retErrorMask = new ObjectToRef_ErrorMask();
            errorMask = retErrorMask;
            SetTo_Internal(rhs, def, retErrorMask, cmds);
        }

        private void SetTo_Internal(ObjectToRef rhs, IObjectToRef def, ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds)
        {
            try
            {
                if (rhs.KeyField_Property.HasBeenSet)
                {
                    this.KeyField_Property.Set(
                        rhs.KeyField,
                        cmds);
                }
                else
                {
                    if (def == null)
                    {
                        this.KeyField_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        this.KeyField_Property.Set(
                            def.KeyField,
                            cmds);
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(0, ex);
                }
            }
            try
            {
                if (rhs.SomeField_Property.HasBeenSet)
                {
                    this.SomeField_Property.Set(
                        rhs.SomeField,
                        cmds);
                }
                else
                {
                    if (def == null)
                    {
                        this.SomeField_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        this.SomeField_Property.Set(
                            def.SomeField,
                            cmds);
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(1, ex);
                }
            }
        }
        #endregion
        #region XML Translation
        public static ObjectToRef CreateFromXML(XElement root)
        {
            var ret = new ObjectToRef();
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask,
                cmds: null);
            return ret;
        }

        public static ObjectToRef CreateFromXML(XElement root, out ObjectToRef_ErrorMask errorMask)
        {
            var ret = new ObjectToRef();
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                doMasks: true,
                mask: out errorMask,
                cmds: null);
            return ret;
        }

        public void CopyInFromXML(XElement root, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask,
                cmds: cmds);
        }

        public virtual void CopyInFromXML(XElement root, out ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void WriteXMLToStream(Stream stream)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                WriteXML(writer);
            }
        }

        public void WriteXML(XmlWriter writer, out ObjectToRef_ErrorMask errorMask, string name = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: true,
                mask: out errorMask);
        }

        public void WriteXML(XmlWriter writer, string name)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask);
        }

        public void WriteXML(XmlWriter writer)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: null,
                item: this,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask);
        }

        #endregion
        #region Mask
        #endregion
        object ICopyable.Copy()
        {
            return this.Copy_ToObject(def: null);
        }

        protected object Copy_ToObject(object def = null)
        {
            var ret = new ObjectToRef();
            ret.CopyFieldsFrom_Generic(this, def: def, cmds: null);
            return ret;
        }

        void ICopyInAble.CopyFieldsFrom(object rhs, object def, NotifyingFireParameters? cmds)
        {
            this.CopyFieldsFrom_Generic(rhs, def, cmds);
        }

        protected void CopyFieldsFrom_Generic(object rhs, object def, NotifyingFireParameters? cmds)
        {
            if (rhs is ObjectToRef rhsCast)
            {
                this.CopyFieldsFrom(rhsCast, def as ObjectToRef, cmds);
            }
        }

        public ObjectToRef Copy(IObjectToRefGetter def = null)
        {
            return (ObjectToRef)this.Copy_ToObject(def: def);
        }

        public static ObjectToRef Copy(IObjectToRefGetter item, IObjectToRefGetter def = null)
        {
            var ret = new ObjectToRef();
            ret.CopyFieldsFrom(item, def);
            return ret;
        }

        partial void ClearPartial(NotifyingUnsetParameters? cmds);

        public void Clear(NotifyingUnsetParameters? cmds = null)
        {
            ClearPartial(cmds);
            this.KeyField_Property.Unset(cmds.ToUnsetParams());
            this.SomeField_Property.Unset(cmds.ToUnsetParams());
        }

    }
    #endregion

    #region Interface
    public interface IObjectToRef : IObjectToRefGetter, INoggolloquyClass<IObjectToRef, IObjectToRefGetter>, INoggolloquyClass<ObjectToRef, IObjectToRefGetter>
    {
        new Int32 KeyField { get; set; }
        new INotifyingItem<Int32> KeyField_Property { get; }

        new Boolean SomeField { get; set; }
        new INotifyingItem<Boolean> SomeField_Property { get; }

    }

    public interface IObjectToRefGetter : INoggolloquyObjectGetter
    {
        #region KeyField
        Int32 KeyField { get; }
        INotifyingItemGetter<Int32> KeyField_Property { get; }

        #endregion

        #region SomeField
        Boolean SomeField { get; }
        INotifyingItemGetter<Boolean> SomeField_Property { get; }

        #endregion


        #region XML Translation
        #endregion
        #region Mask
        #endregion
    }

    #endregion

    #region Extensions
    public static class ObjectToRefCommon
    {
        public static Type GetNthType(ushort index)
        {
            switch (index)
            {
                case 0:
                    return typeof(Int32);
                case 1:
                    return typeof(Boolean);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static object GetNthObject(ushort index, IObjectToRefGetter obj)
        {
            switch (index)
            {
                case 0:
                    return obj.KeyField;
                case 1:
                    return obj.SomeField;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static string GetNthName(ushort index)
        {
            switch (index)
            {
                case 0:
                    return "KeyField";
                case 1:
                    return "SomeField";
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            switch (index)
            {
                default:
                    return false;
            }
        }

        #region Copy Fields From
        public static void CopyFieldsFrom(IObjectToRef item, IObjectToRefGetter rhs, IObjectToRefGetter def, ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds)
        {
            try
            {
                if (rhs.KeyField_Property.HasBeenSet)
                {
                    item.KeyField_Property.Set(
                        rhs.KeyField,
                        cmds);
                }
                else
                {
                    if (def == null)
                    {
                        item.KeyField_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        item.KeyField_Property.Set(
                            def.KeyField,
                            cmds);
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(0, ex);
                }
            }
            try
            {
                if (rhs.SomeField_Property.HasBeenSet)
                {
                    item.SomeField_Property.Set(
                        rhs.SomeField,
                        cmds);
                }
                else
                {
                    if (def == null)
                    {
                        item.SomeField_Property.Unset(cmds.ToUnsetParams());
                    }
                    else
                    {
                        item.SomeField_Property.Set(
                            def.SomeField,
                            cmds);
                    }
                }

            }
            catch (Exception ex)
            {
                if (errorMask != null)
                {
                    errorMask.SetNthException(1, ex);
                }
            }
        }

        #endregion

        public static void SetNthObjectHasBeenSet(ushort index, bool on, IObjectToRef obj)
        {
            switch (index)
            {
                case 0:
                    obj.KeyField_Property.SetHasBeenSet(on);
                    break;
                case 1:
                    obj.SomeField_Property.SetHasBeenSet(on);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "KEYFIELD":
                    return 0;
                case "SOMEFIELD":
                    return 1;
                default:
                    throw new ArgumentException($"Queried unknown field: {{str}}");
            }
        }

        public static bool IsReadOnly(ushort index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsNoggolloquy(ushort index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(ushort index, IObjectToRef obj)
        {
            switch (index)
            {
                case 0:
                    return obj.KeyField_Property.HasBeenSet;
                case 1:
                    return obj.SomeField_Property.HasBeenSet;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void SetNthObject(IObjectToRef nog, ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            switch (index)
            {
                case 0:
                    nog.KeyField_Property.Set(
                        ((Int32)obj),
                        cmds);
                    break;
                case 1:
                    nog.SomeField_Property.Set(
                        ((Boolean)obj),
                        cmds);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

    }
    public static class ObjectToRefExt
    {
        public static ObjectToRef Copy_ToNoggolloquy(this IObjectToRefGetter item)
        {
            return ObjectToRef.Copy(item, def: null);
        }

    }
    #endregion

    #region Modules
    #region XML Translation
    #endregion

    #region Mask
    public class ObjectToRef_Mask<T> 
    {
        public T KeyField;
        public T SomeField;
    }

    public class ObjectToRef_ErrorMask : IErrorMask
    {
        public Exception Overall { get; set; }
        private List<string> _warnings;
        public List<string> Warnings
        {
            get
            {
                if (_warnings == null)
                {
                    _warnings = new List<string>();
                }
                return _warnings;
            }
        }
        public Exception KeyField;
        public Exception SomeField;

        public void SetNthException(ushort index, Exception ex)
        {
            switch (index)
            {
                case 0:
                    this.KeyField = ex;
                    break;
                case 1:
                    this.SomeField = ex;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void SetNthMask(ushort index, object obj)
        {
            switch (index)
            {
                case 0:
                    this.KeyField = (Exception)obj;
                    break;
                case 1:
                    this.SomeField = (Exception)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }
    }
    #endregion

    #endregion

    #region Noggolloquy Interfaces
    #endregion

}
