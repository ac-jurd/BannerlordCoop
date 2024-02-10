﻿using Common.Logging.Attributes;
using Common.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameInterface.Services.Settlements.Messages;

[BatchLogMessage]
public record SettlementChangedGarrisonWageLimit : ICommand
{
    public string SettlementId { get; }
    public int GarrisonWagePaymentLimit { get; }

    public SettlementChangedGarrisonWageLimit(string settlementId, int garrisonWagePaymentLimit)
    {
        SettlementId = settlementId;
        GarrisonWagePaymentLimit = garrisonWagePaymentLimit;
    }
}
