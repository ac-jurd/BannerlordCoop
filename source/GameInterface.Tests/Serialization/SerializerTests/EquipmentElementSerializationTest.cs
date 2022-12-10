﻿using GameInterface.Serialization.Impl;
using GameInterface.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using Xunit;
using TaleWorlds.ObjectSystem;
using System.Reflection;

namespace GameInterface.Tests.Serialization.SerializerTests
{
    public class EquipmentElementSerializationTest
    {
        public EquipmentElementSerializationTest()
        {
            MBObjectManager.Init();
        }

        [Fact]
        public void EquipmentElement_Serialize()
        {
            EquipmentElement equipmentElement = new EquipmentElement();

            BinaryPackageFactory factory = new BinaryPackageFactory();
            EquipmentElementBinaryPackage package = new EquipmentElementBinaryPackage(equipmentElement, factory);

            package.Pack();

            byte[] bytes = BinaryFormatterSerializer.Serialize(package);

            Assert.NotEmpty(bytes);
        }

        static FieldInfo _damage = typeof(ItemModifier).GetField("_damage", BindingFlags.Instance | BindingFlags.NonPublic);
        static FieldInfo _armor = typeof(ItemModifier).GetField("_armor", BindingFlags.Instance | BindingFlags.NonPublic);
        [Fact]
        public void EquipmentElement_Full_Serialization()
        {
            ItemObject itemobj = MBObjectManager.Instance.CreateObject<ItemObject>();
            ItemObject itemobj2 = MBObjectManager.Instance.CreateObject<ItemObject>();
            ItemModifier ItemModifier = MBObjectManager.Instance.CreateObject<ItemModifier>();

            ItemModifier.ModifyDamage(10);
            ItemModifier.ModifyArmor(15);

            EquipmentElement equipmentElement = new EquipmentElement(itemobj,ItemModifier,itemobj2);
            BinaryPackageFactory factory = new BinaryPackageFactory();
            EquipmentElementBinaryPackage package = new EquipmentElementBinaryPackage(equipmentElement, factory);

            package.Pack();

            byte[] bytes = BinaryFormatterSerializer.Serialize(package);

            Assert.NotEmpty(bytes);

            object obj = BinaryFormatterSerializer.Deserialize(bytes);

            Assert.IsType<EquipmentElementBinaryPackage>(obj);

            EquipmentElementBinaryPackage returnedPackage = (EquipmentElementBinaryPackage)obj;

            EquipmentElement newEquipmentElement = returnedPackage.Unpack<EquipmentElement>();
            
            Assert.Equal(_damage.GetValue(equipmentElement.ItemModifier),
                         _damage.GetValue(newEquipmentElement.ItemModifier));

            Assert.Equal(_armor.GetValue(equipmentElement.ItemModifier),
                         _armor.GetValue(newEquipmentElement.ItemModifier));

            Assert.Equal(equipmentElement.Item.StringId, newEquipmentElement.Item.StringId);
            Assert.Equal(equipmentElement.CosmeticItem.StringId, newEquipmentElement.CosmeticItem.StringId);
        }
    }
}
