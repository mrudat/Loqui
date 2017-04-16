﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noggog.Notifying;

namespace Noggolloquy.Tests
{
    public class ObjectToRef_CustomMade : IObjectToRef
    {
        public INotifyingItem<int> KeyField_Property { get; } = new NotifyingItem<int>();
        public int KeyField { get => KeyField_Property.Value; set => KeyField_Property.Value = value; }
        INotifyingItemGetter<int> IObjectToRefGetter.KeyField_Property => KeyField_Property;

        public INotifyingItem<bool> SomeField_Property { get; } = new NotifyingItem<bool>();
        public bool SomeField { get => SomeField_Property.Value; set => SomeField_Property.Value = value; }
        INotifyingItemGetter<bool> IObjectToRefGetter.SomeField_Property => SomeField_Property;

        public INoggolloquyRegistration Registration => ObjectToRef.Registration;
    }
}
