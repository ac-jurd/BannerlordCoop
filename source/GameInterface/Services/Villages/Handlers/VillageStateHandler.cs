﻿﻿using Common.Logging;
using Common.Messaging;
using GameInterface.Services.ObjectManager;
using GameInterface.Services.Villages.Messages;
using GameInterface.Services.Villages.Patches;
using Serilog;
using System;
using TaleWorlds.CampaignSystem.Settlements;

namespace GameInterface.Services.Villages.Handlers;

/// <summary>
/// Handles VillageState Changes (e.g. Raided, Pillaged, Normal).
/// </summary>
public class VillageStateHandler : IHandler
{
    private static readonly ILogger Logger = LogManager.GetLogger<VillageStateHandler>();

    private readonly IMessageBroker messageBroker;
    private readonly IObjectManager objectManager;
    public VillageStateHandler(IMessageBroker messageBroker, IObjectManager objectManager)
    {
        this.messageBroker = messageBroker; 
        this.objectManager = objectManager;
 
        messageBroker.Subscribe<ChangeVillageState>(Handle);
    }

    private void Handle(MessagePayload<ChangeVillageState> payload)
    {
        var obj = payload.What;

        if(objectManager.TryGetObject<Village>(obj.SettlementId, out var village) == false)
        {
            Logger.Error("Unable to find Village ({villageId})", obj.SettlementId);
            return;
        }

        VillagePatches.RunVillageStateChange(village, (Village.VillageStates)obj.State);
    }


    public void Dispose()
    {
        messageBroker?.Unsubscribe<ChangeVillageState>(Handle);
    }
}