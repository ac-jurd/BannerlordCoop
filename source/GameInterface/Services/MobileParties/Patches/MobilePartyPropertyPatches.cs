﻿using Common.Logging;
using Common.Messaging;
using GameInterface.Policies;
using GameInterface.Services.MobileParties.Messages;
using HarmonyLib;
using Serilog;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace GameInterface.Services.MobileParties.Patches;

[HarmonyPatch(typeof(MobileParty))]
public class MobilePartyPropertyPatches
{
    private static readonly ILogger Logger = LogManager.GetLogger<MobilePartyPropertyPatches>();

    [HarmonyPatch(nameof(MobileParty.Army), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetArmyPrefix(MobileParty __instance, Army value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Army, __instance.StringId, value?.LeaderParty.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.CustomName), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetCustomNamePrefix(MobileParty __instance, TextObject value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.CustomName, __instance.StringId, value?.Value);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.LastVisitedSettlement), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetLastVisitedSettlementPrefix(MobileParty __instance, Settlement value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.LastVisitedSettlement, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Aggressiveness), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetAggressivenessPrefix(MobileParty __instance, float value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Aggressiveness, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.ArmyPositionAdder), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetArmyPositionAdderPrefix(MobileParty __instance, Vec2 value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.ArmyPositionAdder, __instance.StringId, value.x.ToString(), value.y.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Objective), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetObjectivePrefix(MobileParty __instance, int value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Objective, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    //[HarmonyPatch(nameof(MobileParty.Ai), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetAiPrefix(MobileParty __instance, MobilePartyAi value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    //Is this one needed?
    //    var message = new MobilePartyPropertyChanged(PropertyType.Ai, __instance.StringId, value.ToString());
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    //[HarmonyPatch(nameof(MobileParty.Party), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetPartyPrefix(MobileParty __instance, PartyBase value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    var message = new MobilePartyPropertyChanged(PropertyType.Party, __instance.StringId, value.MobileParty?.StringId);
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    [HarmonyPatch(nameof(MobileParty.IsActive), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsActivePrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsActive, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.ThinkParamsCache), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetThinkParamsCachePrefix(MobileParty __instance, PartyThinkParams value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        //Is this needed?
        var message = new MobilePartyPropertyChanged(PropertyType.ThinkParamsCache, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    //[HarmonyPatch(nameof(MobileParty.ShortTermBehavior), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetShortTermBehaviorPrefix(MobileParty __instance, AiBehavior value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    var message = new MobilePartyPropertyChanged(PropertyType.ShortTermBehaviour, __instance.StringId, value.ToString());
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    [HarmonyPatch(nameof(MobileParty.IsPartyTradeActive), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsPartyTradeActivePrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsPartyTradeActive, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.PartyTradeGold), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetPartyTradeGoldPrefix(MobileParty __instance, int value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.PartyTradeGold, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.PartyTradeTaxGold), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetPartyTradeTaxGoldPrefix(MobileParty __instance, int value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.PartyTradeTaxGold, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    //StationaryStartTime causes a lot of lag, not sure why but looks like some circular reference

    //[HarmonyPatch(nameof(MobileParty.StationaryStartTime), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetStationaryStartTimePrefix(MobileParty __instance, CampaignTime value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    var message = new MobilePartyPropertyChanged(PropertyType.StationaryStartTime, __instance.StringId, value.NumTicks.ToString());
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    [HarmonyPatch(nameof(MobileParty.VersionNo), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetVersionNoPrefix(MobileParty __instance, int value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.VersionNo, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.ShouldJoinPlayerBattles), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetShouldJoinPlayerBattlesPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.ShouldJoinPlayerBattles, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsDisbanding), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsDisbandingPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsDisbanding, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.CurrentSettlement), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetCurentSettlementPrefix(MobileParty __instance, Settlement value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.CurrentSettlement, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.AttachedTo), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetAttachedToPrefix(MobileParty __instance, MobileParty value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.AttachedTo, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.BesiegerCamp), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetBesiegerCampPrefix(MobileParty __instance, BesiegerCamp value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.BesiegerCamp, __instance.StringId, value?.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Scout), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetScoutPrefix(MobileParty __instance, Hero value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Scout, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Engineer), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetEngineerPrefix(MobileParty __instance, Hero value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Engineer, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Quartermaster), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetQuartermasterPrefix(MobileParty __instance, Hero value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Quartermaster, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.Surgeon), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetSurgeonPrefix(MobileParty __instance, Hero value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.Surgeon, __instance.StringId, value?.StringId);
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    //[HarmonyPatch(nameof(MobileParty.ActualClan), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetActualClanPrefix(MobileParty __instance, Clan value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    var message = new MobilePartyPropertyChanged(PropertyType.ActualClan, __instance.StringId, value?.StringId);
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    [HarmonyPatch(nameof(MobileParty.RecentEventsMorale), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetRecentEventsMoralePrefix(MobileParty __instance, float value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.RecentEventsMorale, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.EventPositionAdder), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetEventPositionAdderPrefix(MobileParty __instance, Vec2 value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.EventPositionAdder, __instance.StringId, value.X.ToString(), value.Y.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    //[HarmonyPatch(nameof(MobileParty.IsInspected), MethodType.Setter)]
    //[HarmonyPrefix]
    //private static bool SetIsInspectedPrefix(MobileParty __instance, bool value)
    //{
    //    if (CallOriginalPolicy.IsOriginalAllowed()) return true;

    //    var message = new MobilePartyPropertyChanged(PropertyType.IsInspected, __instance.StringId, value.ToString());
    //    MessageBroker.Instance.Publish(__instance, message);

    //    return ModInformation.IsServer;
    //}

    [HarmonyPatch(nameof(MobileParty.MapEventSide), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetMapEventSidePrefix(MobileParty __instance, MapEventSide value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.MapEventSide, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.PartyComponent), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetPartyComponentPrefix(MobileParty __instance, PartyComponent value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.PartyComponent, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsMilitia), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsMilitaPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsMilita, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsLordParty), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsLordPartyPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsLordParty, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsVillager), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsVillagerPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsVillager, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsCaravan), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsCaravanPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsCaravan, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsGarrison), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsGarrisonPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsGarrison, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsCustomParty), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsCustomPartyPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsCustomParty, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }

    [HarmonyPatch(nameof(MobileParty.IsBandit), MethodType.Setter)]
    [HarmonyPrefix]
    private static bool SetIsBanditPrefix(MobileParty __instance, bool value)
    {
        if (CallOriginalPolicy.IsOriginalAllowed()) return true;

        var message = new MobilePartyPropertyChanged(PropertyType.IsBandit, __instance.StringId, value.ToString());
        MessageBroker.Instance.Publish(__instance, message);

        return ModInformation.IsServer;
    }
}

public enum PropertyType
{
    Army,
    CustomName,
    LastVisitedSettlement,
    Aggressiveness,
    ArmyPositionAdder,
    Objective,
    Ai,
    Party,
    IsActive,
    ThinkParamsCache,
    ShortTermBehaviour,
    IsPartyTradeActive,
    PartyTradeGold,
    PartyTradeTaxGold,
    StationaryStartTime,
    VersionNo,
    ShouldJoinPlayerBattles,
    IsDisbanding,
    CurrentSettlement,
    AttachedTo,
    BesiegerCamp,
    Scout,
    Engineer,
    Quartermaster,
    Surgeon,
    ActualClan,
    RecentEventsMorale,
    EventPositionAdder,
    IsInspected,
    MapEventSide,
    PartyComponent,
    IsMilita,
    IsLordParty,
    IsVillager,
    IsCaravan,
    IsGarrison,
    IsCustomParty,
    IsBandit,
}