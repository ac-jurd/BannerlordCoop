﻿using Common.Messaging;
using ProtoBuf;

namespace Coop.Core.Server.Services.Kingdoms.Messages
{
    /// <summary>
    /// Add policy has been approved by server
    /// </summary>
    [ProtoContract(SkipConstructor = true)]
    public record NetworkAddPolicyApproved : ICommand
    {
        [ProtoMember(1)]
        public string PolicyId { get; }
        [ProtoMember(2)]
        public string KingdomId { get; }

        public NetworkAddPolicyApproved(string policyId, string kingdomId)
        {
            PolicyId = policyId;
            KingdomId = kingdomId;
        }
    }
}