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
using Noggolloquy.Tests.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Noggolloquy.Xml;

namespace Noggolloquy.Tests
{
    #region Class
    public partial class ObjectToRef : IObjectToRef, INoggolloquyObjectSetter, IEquatable<ObjectToRef>
    {
        INoggolloquyRegistration INoggolloquyObject.Registration => ObjectToRef_Registration.Instance;
        public static ObjectToRef_Registration Registration => ObjectToRef_Registration.Instance;

        public ObjectToRef()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #region KeyField
        protected readonly INotifyingItem<Int32> _KeyField = new NotifyingItem<Int32>(
            default(Int32),
            markAsSet: false);
        public INotifyingItem<Int32> KeyField_Property => _KeyField;
        public Int32 KeyField
        {
            get => this._KeyField.Value;
            set => this._KeyField.Set(value);
        }
        INotifyingItem<Int32> IObjectToRef.KeyField_Property => this.KeyField_Property;
        INotifyingItemGetter<Int32> IObjectToRefGetter.KeyField_Property => this.KeyField_Property;
        #endregion
        #region SomeField
        protected readonly INotifyingItem<Boolean> _SomeField = new NotifyingItem<Boolean>(
            default(Boolean),
            markAsSet: false);
        public INotifyingItem<Boolean> SomeField_Property => _SomeField;
        public Boolean SomeField
        {
            get => this._SomeField.Value;
            set => this._SomeField.Set(value);
        }
        INotifyingItem<Boolean> IObjectToRef.SomeField_Property => this.SomeField_Property;
        INotifyingItemGetter<Boolean> IObjectToRefGetter.SomeField_Property => this.SomeField_Property;
        #endregion

        #region Noggolloquy Getter Interface

        protected object GetNthObject(ushort index) => ObjectToRefCommon.GetNthObject(index, this);
        object INoggolloquyObjectGetter.GetNthObject(ushort index) => this.GetNthObject(index);

        protected bool GetNthObjectHasBeenSet(ushort index) => ObjectToRefCommon.GetNthObjectHasBeenSet(index, this);
        bool INoggolloquyObjectGetter.GetNthObjectHasBeenSet(ushort index) => this.GetNthObjectHasBeenSet(index);

        protected void UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => ObjectToRefCommon.UnsetNthObject(index, this, cmds);
        void INoggolloquyObjectSetter.UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => this.UnsetNthObject(index, cmds);

        #endregion

        #region Noggolloquy Interface
        protected void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            ObjectToRefCommon.SetNthObjectHasBeenSet(index, on, this);
        }
        void INoggolloquyObjectSetter.SetNthObjectHasBeenSet(ushort index, bool on) => this.SetNthObjectHasBeenSet(index, on);

        public void CopyFieldsFrom(
            IObjectToRefGetter rhs,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            ObjectToRefCommon.CopyFieldsFrom(
                item: this,
                rhs: rhs,
                def: def,
                doErrorMask: false,
                errorMask: null,
                copyMask: copyMask,
                cmds: cmds);
        }

        public void CopyFieldsFrom(
            IObjectToRefGetter rhs,
            out ObjectToRef_ErrorMask errorMask,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            ObjectToRef_ErrorMask retErrorMask = null;
            Func<ObjectToRef_ErrorMask> maskGetter = () =>
            {
                if (retErrorMask == null)
                {
                    retErrorMask = new ObjectToRef_ErrorMask();
                }
                return retErrorMask;
            };
            ObjectToRefCommon.CopyFieldsFrom(
                item: this,
                rhs: rhs,
                def: def,
                doErrorMask: false,
                errorMask: maskGetter,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = retErrorMask;
        }

        #endregion

        #region To String
        public override string ToString()
        {
            return INoggolloquyObjectExt.PrintPretty(this);
        }
        #endregion


        #region Equals and Hash
        public override bool Equals(object obj)
        {
            if (!(obj is ObjectToRef rhs)) return false;
            return Equals(rhs);
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


        #region XML Translation
        public static ObjectToRef Create_XML(XElement root)
        {
            var ret = new ObjectToRef();
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                skipReadonly: false,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask,
                cmds: null);
            return ret;
        }

        public static ObjectToRef Create_XML(XElement root, out ObjectToRef_ErrorMask errorMask)
        {
            var ret = new ObjectToRef();
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: ret,
                skipReadonly: false,
                doMasks: true,
                mask: out errorMask,
                cmds: null);
            return ret;
        }

        public void CopyIn_XML(XElement root, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipReadonly: true,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask,
                cmds: cmds);
        }

        public virtual void CopyIn_XML(XElement root, out ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipReadonly: true,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void Write_XML(Stream stream)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(writer);
            }
        }

        public void Write_XML(Stream stream, out ObjectToRef_ErrorMask errorMask)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(writer, out errorMask);
            }
        }

        public void Write_XML(XmlWriter writer, out ObjectToRef_ErrorMask errorMask, string name = null)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: true,
                mask: out errorMask);
        }

        public void Write_XML(XmlWriter writer, string name)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: name,
                item: this,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask);
        }

        public void Write_XML(XmlWriter writer)
        {
            NoggXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.Write(
                writer: writer,
                name: null,
                item: this,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask);
        }

        #endregion

        public ObjectToRef Copy(
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null)
        {
            return ObjectToRef.Copy(
                this,
                copyMask: copyMask,
                def: def);
        }

        public static ObjectToRef Copy(
            IObjectToRef item,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null)
        {
            ObjectToRef ret;
            if (item.GetType().Equals(typeof(ObjectToRef)))
            {
                ret = new ObjectToRef();
            }
            else
            {
                ret = (ObjectToRef)Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public static CopyType Copy<CopyType>(
            CopyType item,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null)
            where CopyType : class, IObjectToRef
        {
            CopyType ret;
            if (item.GetType().Equals(typeof(ObjectToRef)))
            {
                ret = new ObjectToRef() as CopyType;
            }
            else
            {
                ret = (CopyType)Activator.CreateInstance(item.GetType());
            }
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                doErrorMask: false,
                errorMask: null,
                cmds: null,
                def: def);
            return ret;
        }

        public static ObjectToRef Copy_ToNoggolloquy(
            IObjectToRefGetter item,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null)
        {
            var ret = new ObjectToRef();
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        void INoggolloquyObjectSetter.SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds) => this.SetNthObject(index, obj, cmds);
        protected void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            switch (index)
            {
                case 0:
                    this._KeyField.Set(
                        (Int32)obj,
                        cmds);
                    break;
                case 1:
                    this._SomeField.Set(
                        (Boolean)obj,
                        cmds);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        partial void ClearPartial(NotifyingUnsetParameters? cmds);

        protected void CallClearPartial_Internal(NotifyingUnsetParameters? cmds)
        {
            ClearPartial(cmds);
        }

        public void Clear(NotifyingUnsetParameters? cmds = null)
        {
            CallClearPartial_Internal(cmds);
            ObjectToRefCommon.Clear(this, cmds);
        }

        public static ObjectToRef Create(IEnumerable<KeyValuePair<ushort, object>> fields)
        {
            var ret = new ObjectToRef();
            INoggolloquyObjectExt.CopyFieldsIn(ret, fields, def: null, skipReadonly: false, cmds: null);
            return ret;
        }

        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, ObjectToRef obj)
        {
            INoggolloquyObjectExt.CopyFieldsIn(obj, fields, def: null, skipReadonly: false, cmds: null);
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

    public interface IObjectToRefGetter : INoggolloquyObject
    {
        #region KeyField
        Int32 KeyField { get; }
        INotifyingItemGetter<Int32> KeyField_Property { get; }

        #endregion
        #region SomeField
        Boolean SomeField { get; }
        INotifyingItemGetter<Boolean> SomeField_Property { get; }

        #endregion

    }

    #endregion

}

namespace Noggolloquy.Tests.Internals
{
    #region Registration
    public class ObjectToRef_Registration : INoggolloquyRegistration
    {
        public static readonly ObjectToRef_Registration Instance = new ObjectToRef_Registration();

        public static ProtocolDefinition ProtocolDefinition => ProtocolDefinition_NoggolloquyTests.Definition;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_NoggolloquyTests.ProtocolKey,
            msgID: 3,
            version: 0);

        public const string GUID = "39bed53a-0f81-4fdc-8ce4-84563c3125cf";

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(ObjectToRef_Mask<>);

        public static readonly Type ErrorMaskType = typeof(ObjectToRef_ErrorMask);

        public static readonly Type ClassType = typeof(ObjectToRef);

        public const string FullName = "Noggolloquy.Tests.ObjectToRef";

        public const string Name = "ObjectToRef";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "KEYFIELD":
                    return 0;
                case "SOMEFIELD":
                    return 1;
                default:
                    throw new ArgumentException($"Queried unknown field: {str}");
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

        public static bool GetNthIsSingleton(ushort index)
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

        #region Interface
        ProtocolDefinition INoggolloquyRegistration.ProtocolDefinition => ProtocolDefinition;
        ObjectKey INoggolloquyRegistration.ObjectKey => ObjectKey;
        string INoggolloquyRegistration.GUID => GUID;
        int INoggolloquyRegistration.FieldCount => FieldCount;
        Type INoggolloquyRegistration.MaskType => MaskType;
        Type INoggolloquyRegistration.ErrorMaskType => ErrorMaskType;
        Type INoggolloquyRegistration.ClassType => ClassType;
        string INoggolloquyRegistration.FullName => FullName;
        string INoggolloquyRegistration.Name => Name;
        byte INoggolloquyRegistration.GenericCount => GenericCount;
        Type INoggolloquyRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? INoggolloquyRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool INoggolloquyRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool INoggolloquyRegistration.GetNthIsNoggolloquy(ushort index) => GetNthIsNoggolloquy(index);
        bool INoggolloquyRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string INoggolloquyRegistration.GetNthName(ushort index) => GetNthName(index);
        bool INoggolloquyRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool INoggolloquyRegistration.IsReadOnly(ushort index) => IsReadOnly(index);
        Type INoggolloquyRegistration.GetNthType(ushort index) => GetNthType(index);
        #endregion

    }
    #endregion

    #region Extensions
    public static class ObjectToRefCommon
    {
        #region Copy Fields From
        public static void CopyFieldsFrom(
            this IObjectToRef item,
            IObjectToRefGetter rhs,
            IObjectToRefGetter def,
            bool doErrorMask,
            Func<ObjectToRef_ErrorMask> errorMask,
            ObjectToRef_CopyMask copyMask,
            NotifyingFireParameters? cmds)
        {
            if (copyMask?.KeyField ?? true)
            {
                try
                {
                    item.KeyField_Property.SetToWithDefault(
                        rhs.KeyField_Property,
                        def?.KeyField_Property,
                        cmds);
                }
                catch (Exception ex)
                {
                    if (doErrorMask)
                    {
                        errorMask().SetNthException(0, ex);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            if (copyMask?.SomeField ?? true)
            {
                try
                {
                    item.SomeField_Property.SetToWithDefault(
                        rhs.SomeField_Property,
                        def?.SomeField_Property,
                        cmds);
                }
                catch (Exception ex)
                {
                    if (doErrorMask)
                    {
                        errorMask().SetNthException(1, ex);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        #endregion

        public static void SetNthObjectHasBeenSet(
            ushort index,
            bool on,
            IObjectToRef obj,
            NotifyingFireParameters? cmds = null)
        {
            switch (index)
            {
                case 0:
                    obj.KeyField_Property.HasBeenSet = on;
                    break;
                case 1:
                    obj.SomeField_Property.HasBeenSet = on;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static void UnsetNthObject(
            ushort index,
            IObjectToRef obj,
            NotifyingUnsetParameters? cmds = null)
        {
            switch (index)
            {
                case 0:
                    obj.KeyField_Property.Unset(cmds);
                    break;
                case 1:
                    obj.SomeField_Property.Unset(cmds);
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthObjectHasBeenSet(
            ushort index,
            IObjectToRef obj)
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

        public static object GetNthObject(
            ushort index,
            IObjectToRefGetter obj)
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

        public static void Clear(
            IObjectToRef item,
            NotifyingUnsetParameters? cmds = null)
        {
            item.KeyField_Property.Unset(cmds.ToUnsetParams());
            item.SomeField_Property.Unset(cmds.ToUnsetParams());
        }
    }
    #endregion

    #region Modules

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
    public class ObjectToRef_CopyMask
    {
        public bool KeyField;
        public bool SomeField;

    }
    #endregion


    #endregion

}
