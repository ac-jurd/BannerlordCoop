﻿using Coop.Core.Server.Services.Settlements.Messages;
using Coop.IntegrationTests.Environment;
using Coop.IntegrationTests.Environment.Instance;
using GameInterface.Services.Settlements.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coop.IntegrationTests.Settlements;
public class SettlementBribePaidTest
{
    // Creates a test environment with 1 server and 2 clients by default
    internal TestEnvironment TestEnvironment { get; } = new TestEnvironment();

    /// <summary>
    /// Used to Test that client recieves BribePaid messsages.
    /// </summary>
    [Fact]
    public void ServerSettlementBribePaidChanged_Publishes_AllClients()
    {
        // Arrange
        string settlementId = "Settlement1";
        int bribePaid = 15;
        var triggerMessage = new SettlementChangedBribePaid(settlementId, bribePaid);

        var server = TestEnvironment.Server;

        // Act
        server.SimulateMessage(this, triggerMessage);

        // Assert
        // Verify the server sends a single message to it's game interface
        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkChangeSettlementBribePaid>());

        // Verify the all clients send a single message to their game interfaces
        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeSettlementBribePaid>());
        }
    }
}
