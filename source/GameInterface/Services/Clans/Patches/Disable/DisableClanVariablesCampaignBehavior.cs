﻿using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;

namespace GameInterface.Services.Clans.Patches.Disable;

[HarmonyPatch(typeof(ClanVariablesCampaignBehavior))]
internal class DisableClanVariablesCampaignBehavior
{
    //[HarmonyPatch(nameof(ClanVariablesCampaignBehavior.RegisterEvents))]
    //static bool Prefix() => false;
}
