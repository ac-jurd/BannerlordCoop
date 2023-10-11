﻿using Coop.Core.Client.States;
using GameInterface.Policies;
using System;
using System.Collections.Generic;

namespace Coop.Core.Client.Policies;

internal class SyncPolicy : ISyncPolicy
{
    private readonly IClientLogic clientLogic;

    public SyncPolicy(IClientLogic clientLogic)
    {
        this.clientLogic = clientLogic;
    }

    private readonly HashSet<Type> syncStates = new HashSet<Type>
    {
        typeof(CampaignState),
        typeof(MissionState)
    };

    public bool AllowOriginalCalls => Allow();

    private bool Allow()
    {
        // When the client state is not in Campaign or Mission allow original calls
        if (syncStates.Contains(clientLogic.State.GetType()) == false) return true;

        return false;
    }
}
