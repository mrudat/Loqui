/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loqui;
using Noggog;
using Noggog.Notifying;
using Loqui.Tests.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Loqui.Xml;

namespace Loqui.Tests
{
    #region Class
    public partial class ObjectToRef : IObjectToRef, ILoquiObjectSetter, IEquatable<ObjectToRef>
    {
        ILoquiRegistration ILoquiObject.Registration => ObjectToRef_Registration.Instance;
        public static ObjectToRef_Registration Registration => ObjectToRef_Registration.Instance;

        public ObjectToRef()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #region KeyField
        protected readonly INotifyingItem<Int32> _KeyField = NotifyingItem.Factory<Int32>(markAsSet: false);
        public INotifyingItem<Int32> KeyField_Property => _KeyField;
        public Int32 KeyField
        {
            get => this._KeyField.Item;
            set => this._KeyField.Set(value);
        }
        INotifyingItem<Int32> IObjectToRef.KeyField_Property => this.KeyField_Property;
        INotifyingItemGetter<Int32> IObjectToRefGetter.KeyField_Property => this.KeyField_Property;
        #endregion
        #region SomeField
        protected readonly INotifyingItem<Boolean> _SomeField = NotifyingItem.Factory<Boolean>(markAsSet: false);
        public INotifyingItem<Boolean> SomeField_Property => _SomeField;
        public Boolean SomeField
        {
            get => this._SomeField.Item;
            set => this._SomeField.Set(value);
        }
        INotifyingItem<Boolean> IObjectToRef.SomeField_Property => this.SomeField_Property;
        INotifyingItemGetter<Boolean> IObjectToRefGetter.SomeField_Property => this.SomeField_Property;
        #endregion

        #region Loqui Getter Interface

        protected object GetNthObject(ushort index) => ObjectToRefCommon.GetNthObject(index, this);
        object ILoquiObjectGetter.GetNthObject(ushort index) => this.GetNthObject(index);

        protected bool GetNthObjectHasBeenSet(ushort index) => ObjectToRefCommon.GetNthObjectHasBeenSet(index, this);
        bool ILoquiObjectGetter.GetNthObjectHasBeenSet(ushort index) => this.GetNthObjectHasBeenSet(index);

        protected void UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => ObjectToRefCommon.UnsetNthObject(index, this, cmds);
        void ILoquiObjectSetter.UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => this.UnsetNthObject(index, cmds);

        #endregion

        #region Loqui Interface
        protected void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            ObjectToRefCommon.SetNthObjectHasBeenSet(index, on, this);
        }
        void ILoquiObjectSetter.SetNthObjectHasBeenSet(ushort index, bool on) => this.SetNthObjectHasBeenSet(index, on);

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
                doErrorMask: true,
                errorMask: maskGetter,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = retErrorMask;
        }

        public void CopyFieldsFrom(
            IObjectToRefGetter rhs,
            bool doErrorMask,
            out ObjectToRef_ErrorMask errorMask,
            ObjectToRef_CopyMask copyMask = null,
            IObjectToRefGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            if (doErrorMask)
            {
                CopyFieldsFrom(
                    rhs: rhs,
                    errorMask: out errorMask,
                    copyMask: copyMask,
                    def: def,
                    cmds: cmds);
            }
            else
            {
                errorMask = null;
                CopyFieldsFrom(
                    rhs: rhs,
                    copyMask: copyMask,
                    def: def,
                    cmds: cmds);
            }
        }

        #endregion

        #region To String
        public override string ToString()
        {
            return ILoquiObjectExt.PrintPretty(this);
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
            if (KeyField_Property.HasBeenSet != rhs.KeyField_Property.HasBeenSet) return false;
            if (KeyField_Property.HasBeenSet)
            {
                if (KeyField != rhs.KeyField) return false;
            }
            if (SomeField_Property.HasBeenSet != rhs.SomeField_Property.HasBeenSet) return false;
            if (SomeField_Property.HasBeenSet)
            {
                if (SomeField != rhs.SomeField) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            if (KeyField_Property.HasBeenSet)
            {
                ret = HashHelper.GetHashCode(KeyField).CombineHashCode(ret);
            }
            if (SomeField_Property.HasBeenSet)
            {
                ret = HashHelper.GetHashCode(SomeField).CombineHashCode(ret);
            }
            return ret;
        }

        #endregion


        #region XML Translation
        public static ObjectToRef Create_XML(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return Create_XML(XElement.Parse(reader.ReadToEnd()));
            }
        }

        public static ObjectToRef Create_XML(XElement root)
        {
            return Create_XML(
                root: root,
                doMasks: false,
                errorMask: out var errorMask);
        }

        public static ObjectToRef Create_XML(
            XElement root,
            out ObjectToRef_ErrorMask errorMask)
        {
            return Create_XML(
                root: root,
                doMasks: true,
                errorMask: out errorMask);
        }

        public static ObjectToRef Create_XML(
            XElement root,
            bool doMasks,
            out ObjectToRef_ErrorMask errorMask)
        {
            ObjectToRef_ErrorMask errMaskRet = null;
            var ret = Create_XML_Internal(
                root: root,
                doMasks: doMasks,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new ObjectToRef_ErrorMask()) : default(Func<ObjectToRef_ErrorMask>));
            errorMask = errMaskRet;
            return ret;
        }

        private static ObjectToRef Create_XML_Internal(
            XElement root,
            bool doMasks,
            Func<ObjectToRef_ErrorMask> errorMask)
        {
            var ret = new ObjectToRef();
            try
            {
                foreach (var elem in root.Elements())
                {
                    if (!elem.TryGetAttribute("name", out XAttribute name)) continue;
                    Fill_XML_Internal(
                        item: ret,
                        root: elem,
                        name: name.Value,
                        doMasks: doMasks,
                        errorMask: errorMask);
                }
            }
            catch (Exception ex)
            {
                if (!doMasks) throw;
                errorMask().Overall = ex;
            }
            return ret;
        }

        protected static void Fill_XML_Internal(
            ObjectToRef item,
            XElement root,
            string name,
            bool doMasks,
            Func<ObjectToRef_ErrorMask> errorMask)
        {
            switch (name)
            {
                case "KeyField":
                    try
                    {
                        var tryGet = Int32XmlTranslation.Instance.Parse(
                            root,
                            nullable: false);
                        if (tryGet.Succeeded)
                        {
                            item._KeyField.Item = tryGet.Value.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!doMasks) throw;
                        errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.KeyField, ex);
                    }
                    break;
                case "SomeField":
                    try
                    {
                        var tryGet = BooleanXmlTranslation.Instance.Parse(
                            root,
                            nullable: false);
                        if (tryGet.Succeeded)
                        {
                            item._SomeField.Item = tryGet.Value.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!doMasks) throw;
                        errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.SomeField, ex);
                    }
                    break;
                default:
                    break;
            }
        }
        public void CopyIn_XML(XElement root, NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: false,
                mask: out ObjectToRef_ErrorMask errorMask,
                cmds: cmds);
        }

        public virtual void CopyIn_XML(XElement root, out ObjectToRef_ErrorMask errorMask, NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<ObjectToRef, ObjectToRef_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void Write_XML(Stream stream)
        {
            ObjectToRefCommon.Write_XML(
                this,
                stream);
        }

        public void Write_XML(Stream stream, out ObjectToRef_ErrorMask errorMask)
        {
            ObjectToRefCommon.Write_XML(
                this,
                stream,
                out errorMask);
        }

        public void Write_XML(XmlWriter writer, out ObjectToRef_ErrorMask errorMask, string name = null)
        {
            ObjectToRefCommon.Write_XML(
                writer: writer,
                name: name,
                item: this,
                doMasks: true,
                errorMask: out errorMask);
        }

        public void Write_XML(XmlWriter writer, string name = null)
        {
            ObjectToRefCommon.Write_XML(
                writer: writer,
                name: name,
                item: this,
                doMasks: false,
                errorMask: out ObjectToRef_ErrorMask errorMask);
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

        public static ObjectToRef Copy_ToLoqui(
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

        void ILoquiObjectSetter.SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds) => this.SetNthObject(index, obj, cmds);
        protected void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    this._KeyField.Set(
                        (Int32)obj,
                        cmds);
                    break;
                case ObjectToRef_FieldIndex.SomeField:
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
            ILoquiObjectExt.CopyFieldsIn(ret, fields, def: null, skipProtected: false, cmds: null);
            return ret;
        }

        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, ObjectToRef obj)
        {
            ILoquiObjectExt.CopyFieldsIn(obj, fields, def: null, skipProtected: false, cmds: null);
        }

    }
    #endregion

    #region Interface
    public interface IObjectToRef : IObjectToRefGetter, ILoquiClass<IObjectToRef, IObjectToRefGetter>, ILoquiClass<ObjectToRef, IObjectToRefGetter>
    {
        new Int32 KeyField { get; set; }
        new INotifyingItem<Int32> KeyField_Property { get; }

        new Boolean SomeField { get; set; }
        new INotifyingItem<Boolean> SomeField_Property { get; }

    }

    public interface IObjectToRefGetter : ILoquiObject
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

namespace Loqui.Tests.Internals
{
    #region Field Index
    public enum ObjectToRef_FieldIndex
    {
        KeyField = 0,
        SomeField = 1,
    }
    #endregion

    #region Registration
    public class ObjectToRef_Registration : ILoquiRegistration
    {
        public static readonly ObjectToRef_Registration Instance = new ObjectToRef_Registration();

        public static ProtocolDefinition ProtocolDefinition => ProtocolDefinition_LoquiTests.Definition;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_LoquiTests.ProtocolKey,
            msgID: 3,
            version: 0);

        public const string GUID = "39bed53a-0f81-4fdc-8ce4-84563c3125cf";

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(ObjectToRef_Mask<>);

        public static readonly Type ErrorMaskType = typeof(ObjectToRef_ErrorMask);

        public static readonly Type ClassType = typeof(ObjectToRef);

        public const string FullName = "Loqui.Tests.ObjectToRef";

        public const string Name = "ObjectToRef";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                case "KEYFIELD":
                    return (ushort)ObjectToRef_FieldIndex.KeyField;
                case "SOMEFIELD":
                    return (ushort)ObjectToRef_FieldIndex.SomeField;
                default:
                    return null;
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                case ObjectToRef_FieldIndex.SomeField:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsLoqui(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                case ObjectToRef_FieldIndex.SomeField:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                case ObjectToRef_FieldIndex.SomeField:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static string GetNthName(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    return "KeyField";
                case ObjectToRef_FieldIndex.SomeField:
                    return "SomeField";
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                case ObjectToRef_FieldIndex.SomeField:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static bool IsProtected(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                case ObjectToRef_FieldIndex.SomeField:
                    return false;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static Type GetNthType(ushort index)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    return typeof(Int32);
                case ObjectToRef_FieldIndex.SomeField:
                    return typeof(Boolean);
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        #region Interface
        ProtocolDefinition ILoquiRegistration.ProtocolDefinition => ProtocolDefinition;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        int ILoquiRegistration.FieldCount => FieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => GetNthIsLoqui(index);
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string ILoquiRegistration.GetNthName(ushort index) => GetNthName(index);
        bool ILoquiRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool ILoquiRegistration.IsProtected(ushort index) => IsProtected(index);
        Type ILoquiRegistration.GetNthType(ushort index) => GetNthType(index);
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
                    if (doErrorMask) throw;
                    errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.KeyField, ex);
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
                    if (doErrorMask) throw;
                    errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.SomeField, ex);
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
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    obj.KeyField_Property.HasBeenSet = on;
                    break;
                case ObjectToRef_FieldIndex.SomeField:
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
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    obj.KeyField_Property.Unset(cmds);
                    break;
                case ObjectToRef_FieldIndex.SomeField:
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
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    return obj.KeyField_Property.HasBeenSet;
                case ObjectToRef_FieldIndex.SomeField:
                    return obj.SomeField_Property.HasBeenSet;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public static object GetNthObject(
            ushort index,
            IObjectToRefGetter obj)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    return obj.KeyField;
                case ObjectToRef_FieldIndex.SomeField:
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

        public static ObjectToRef_Mask<bool> GetEqualsMask(
            this IObjectToRefGetter item,
            IObjectToRefGetter rhs)
        {
            var ret = new ObjectToRef_Mask<bool>();
            FillEqualsMask(item, rhs, ret);
            return ret;
        }

        public static void FillEqualsMask(
            this IObjectToRefGetter item,
            IObjectToRefGetter rhs,
            ObjectToRef_Mask<bool> ret)
        {
            ret.KeyField = item.KeyField_Property.Equals(rhs.KeyField_Property, (l, r) => l != r);
            ret.SomeField = item.SomeField_Property.Equals(rhs.SomeField_Property, (l, r) => l != r);
        }

        #region XML Translation
        #region XML Write
        public static void Write_XML(
            IObjectToRefGetter item,
            Stream stream)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: null,
                    item: item,
                    doMasks: false,
                    errorMask: out ObjectToRef_ErrorMask errorMask);
            }
        }

        public static void Write_XML(
            IObjectToRefGetter item,
            Stream stream,
            out ObjectToRef_ErrorMask errorMask)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: null,
                    item: item,
                    doMasks: true,
                    errorMask: out errorMask);
            }
        }

        public static void Write_XML(
            XmlWriter writer,
            string name,
            IObjectToRefGetter item,
            bool doMasks,
            out ObjectToRef_ErrorMask errorMask)
        {
            ObjectToRef_ErrorMask errMaskRet = null;
            Write_XML_Internal(
                writer: writer,
                name: name,
                item: item,
                doMasks: doMasks,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new ObjectToRef_ErrorMask()) : default(Func<ObjectToRef_ErrorMask>));
            errorMask = errMaskRet;
        }

        private static void Write_XML_Internal(
            XmlWriter writer,
            string name,
            IObjectToRefGetter item,
            bool doMasks,
            Func<ObjectToRef_ErrorMask> errorMask)
        {
            try
            {
                using (new ElementWrapper(writer, nameof(ObjectToRef)))
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        writer.WriteAttributeString("name", name);
                    }
                    if (item.KeyField_Property.HasBeenSet)
                    {
                        try
                        {
                            if (item.KeyField_Property.HasBeenSet)
                            {
                                Int32XmlTranslation.Instance.Write(
                                    writer,
                                    nameof(item.KeyField),
                                    item.KeyField);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!doMasks) throw;
                            errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.KeyField, ex);
                        }
                    }
                    if (item.SomeField_Property.HasBeenSet)
                    {
                        try
                        {
                            if (item.SomeField_Property.HasBeenSet)
                            {
                                BooleanXmlTranslation.Instance.Write(
                                    writer,
                                    nameof(item.SomeField),
                                    item.SomeField);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!doMasks) throw;
                            errorMask().SetNthException((ushort)ObjectToRef_FieldIndex.SomeField, ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!doMasks) throw;
                errorMask().Overall = ex;
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region Modules

    #region Mask
    public class ObjectToRef_Mask<T> : IMask<T>
    {
        #region Members
        public T KeyField;
        public T SomeField;
        #endregion

        #region All Equal
        public bool AllEqual(Func<T, bool> eval)
        {
            if (!eval(this.KeyField)) return false;
            if (!eval(this.SomeField)) return false;
            return true;
        }
        #endregion

        #region Translate
        public ObjectToRef_Mask<R> Translate<R>(Func<T, R> eval)
        {
            var ret = new ObjectToRef_Mask<R>();
            ret.KeyField = eval(this.KeyField);
            ret.SomeField = eval(this.SomeField);
            return ret;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg)
        {
            fg.AppendLine($"{nameof(ObjectToRef_Mask<T>)} =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (KeyField != null)
                {
                    fg.AppendLine("KeyField =>");
                    fg.AppendLine("[");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine(KeyField.ToString());
                    }
                    fg.AppendLine("]");
                }
                if (SomeField != null)
                {
                    fg.AppendLine("SomeField =>");
                    fg.AppendLine("[");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine(SomeField.ToString());
                    }
                    fg.AppendLine("]");
                }
            }
            fg.AppendLine("]");
        }
        #endregion

    }

    public class ObjectToRef_ErrorMask : IErrorMask
    {
        #region Members
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
        #endregion

        #region IErrorMask
        public void SetNthException(ushort index, Exception ex)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    this.KeyField = ex;
                    break;
                case ObjectToRef_FieldIndex.SomeField:
                    this.SomeField = ex;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }

        public void SetNthMask(ushort index, object obj)
        {
            ObjectToRef_FieldIndex enu = (ObjectToRef_FieldIndex)index;
            switch (enu)
            {
                case ObjectToRef_FieldIndex.KeyField:
                    this.KeyField = (Exception)obj;
                    break;
                case ObjectToRef_FieldIndex.SomeField:
                    this.SomeField = (Exception)obj;
                    break;
                default:
                    throw new ArgumentException($"Index is out of range: {index}");
            }
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg)
        {
            fg.AppendLine("ObjectToRef_ErrorMask =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (KeyField != null)
                {
                    fg.AppendLine("KeyField =>");
                    fg.AppendLine("[");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine(KeyField.ToString());
                    }
                    fg.AppendLine("]");
                }
                if (SomeField != null)
                {
                    fg.AppendLine("SomeField =>");
                    fg.AppendLine("[");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine(SomeField.ToString());
                    }
                    fg.AppendLine("]");
                }
            }
            fg.AppendLine("]");
        }
        #endregion

        #region Combine
        public ObjectToRef_ErrorMask Combine(ObjectToRef_ErrorMask rhs)
        {
            var ret = new ObjectToRef_ErrorMask();
            ret.KeyField = this.KeyField.Combine(rhs.KeyField);
            ret.SomeField = this.SomeField.Combine(rhs.SomeField);
            return ret;
        }
        public static ObjectToRef_ErrorMask Combine(ObjectToRef_ErrorMask lhs, ObjectToRef_ErrorMask rhs)
        {
            if (lhs != null && rhs != null) return lhs.Combine(rhs);
            return lhs ?? rhs;
        }
        #endregion

    }
    public class ObjectToRef_CopyMask
    {
        #region Members
        public bool KeyField;
        public bool SomeField;
        #endregion

    }
    #endregion


    #endregion

}
