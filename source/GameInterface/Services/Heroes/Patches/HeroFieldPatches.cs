﻿using Common.Logging;
using Common.Messaging;
using GameInterface.Policies;
using GameInterface.Services.Heroes.Messages;
using HarmonyLib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace GameInterface.Services.Heroes.Patches
{
    [HarmonyPatch]
    internal class HeroFieldPatches
    {
        private static readonly ILogger Logger = LogManager.GetLogger<HeroFieldPatches>();

        private static IEnumerable<MethodBase> TargetMethods()
        {
            return AccessTools.GetDeclaredMethods(typeof(Hero));
        }

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> LastTimeStampForActivityTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var lastTimeStampField = AccessTools.Field(typeof(Hero), nameof(Hero.LastTimeStampForActivity));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(LastTimeStampForActivityIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == lastTimeStampField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void LastTimeStampForActivityIntercept(int newTimestamp, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance.LastTimeStampForActivity = newTimestamp;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance.LastTimeStampForActivity = newTimestamp;
                return;
            }

            MessageBroker.Instance.Publish(instance, new LastTimeStampChanged(newTimestamp, instance.StringId));

            instance.LastTimeStampForActivity = newTimestamp;
        }

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> CharacterObjectTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var characterObjectField = AccessTools.Field(typeof(Hero), nameof(Hero._characterObject));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(CharacterObjectIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == characterObjectField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void CharacterObjectIntercept(CharacterObject newCharacterObject, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._characterObject = newCharacterObject;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._characterObject = newCharacterObject;
                return;
            }

            MessageBroker.Instance.Publish(instance, new CharacterObjectChanged(newCharacterObject.StringId, instance.StringId));

            instance._characterObject = newCharacterObject;
        }

        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> FirstNameTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var firstNameField = AccessTools.Field(typeof(Hero), nameof(Hero._firstName));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(FirstNameIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == firstNameField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void FirstNameIntercept(TextObject newName, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._firstName = newName;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._firstName = newName;
                return;
            }

            MessageBroker.Instance.Publish(instance, new FirstNameChanged(newName.Value, instance.StringId));

            instance._firstName = newName;
        }
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> NameTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var nameField = AccessTools.Field(typeof(Hero), nameof(Hero._name));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(NameIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == nameField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void NameIntercept(TextObject newName, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._name = newName;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._name = newName;
                return;
            }

            MessageBroker.Instance.Publish(instance, new NameChanged(newName.Value, instance.StringId));

            instance._name = newName;
        }
        private static IEnumerable<CodeInstruction> HairTagsTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var hairTagsField = AccessTools.Field(typeof(Hero), nameof(Hero.HairTags));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(HairTagsIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == hairTagsField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void HairTagsIntercept(string newTags, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance.HairTags = newTags;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance.HairTags = newTags;
                return;
            }

            MessageBroker.Instance.Publish(instance, new HairTagsChanged(newTags, instance.StringId));

            instance.HairTags = newTags;
        }
        private static IEnumerable<CodeInstruction> BeardTagsTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var beardTagsField = AccessTools.Field(typeof(Hero), nameof(Hero.BeardTags));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(BeardTagsIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == beardTagsField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void BeardTagsIntercept(string newTags, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance.BeardTags = newTags;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance.BeardTags = newTags;
                return;
            }

            MessageBroker.Instance.Publish(instance, new BeardTagsChanged(newTags, instance.StringId));

            instance.BeardTags = newTags;
        }
        private static IEnumerable<CodeInstruction> TattooTagsTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var tattooTagsField = AccessTools.Field(typeof(Hero), nameof(Hero.TattooTags));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(TattooTagsIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == tattooTagsField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void TattooTagsIntercept(string newTags, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance.TattooTags = newTags;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance.TattooTags = newTags;
                return;
            }

            MessageBroker.Instance.Publish(instance, new TattooTagsChanged(newTags, instance.StringId));

            instance.TattooTags = newTags;
        }
        private static IEnumerable<CodeInstruction> HeroStateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var heroStateField = AccessTools.Field(typeof(Hero), nameof(Hero._heroState));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(HeroStateIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == heroStateField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void HeroStateIntercept(int newState, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._heroState = (Hero.CharacterStates)newState;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._heroState = (Hero.CharacterStates)newState;
                return;
            }

            MessageBroker.Instance.Publish(instance, new HeroStateChanged(newState, instance.StringId));

            instance._heroState = (Hero.CharacterStates)newState;
        }
        private static IEnumerable<CodeInstruction> SpcDaysInLocationTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var spcDaysInLocationField = AccessTools.Field(typeof(Hero), nameof(Hero.SpcDaysInLocation));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(SpcDaysInLocationIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == spcDaysInLocationField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void SpcDaysInLocationIntercept(int days, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance.SpcDaysInLocation = days;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance.SpcDaysInLocation = days;
                return;
            }

            MessageBroker.Instance.Publish(instance, new SpcDaysInLocationChanged(days, instance.StringId));

            instance.SpcDaysInLocation = days;
        }
        private static IEnumerable<CodeInstruction> DefaultAgeTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var valueField = AccessTools.Field(typeof(Hero), nameof(Hero._defaultAge));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(DefaultAgeIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == valueField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void DefaultAgeIntercept(int age, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._defaultAge = age;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._defaultAge = age;
                return;
            }

            MessageBroker.Instance.Publish(instance, new DefaultAgeChanged(age, instance.StringId));

            instance._defaultAge = age;
        }
        private static IEnumerable<CodeInstruction> BirthDayTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var valueField = AccessTools.Field(typeof(Hero), nameof(Hero._birthDay));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(BirthDayIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == valueField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void BirthDayIntercept(long birthDay, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._birthDay = new CampaignTime(birthDay);
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._birthDay = new CampaignTime(birthDay);
                return;
            }

            MessageBroker.Instance.Publish(instance, new BirthDayChanged(birthDay, instance.StringId));

            instance._birthDay = new CampaignTime(birthDay);
        }
        private static IEnumerable<CodeInstruction> PowerTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var valueField = AccessTools.Field(typeof(Hero), nameof(Hero._power));
            var fieldIntercept = AccessTools.Method(typeof(HeroFieldPatches), nameof(PowerIntercept));

            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Stfld && instruction.operand as FieldInfo == valueField)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, fieldIntercept);
                }
                else
                {
                    yield return instruction;
                }
            }
        }

        public static void PowerIntercept(float power, Hero instance)
        {
            if (CallOriginalPolicy.IsOriginalAllowed())
            {
                instance._power = power;
                return;
            }
            if (ModInformation.IsClient)
            {
                Logger.Error("Client added unmanaged item: {callstack}", Environment.StackTrace);
                instance._power = power;
                return;
            }

            MessageBroker.Instance.Publish(instance, new PowerChanged(power, instance.StringId));

            instance._power = power;
        }
    }
}
