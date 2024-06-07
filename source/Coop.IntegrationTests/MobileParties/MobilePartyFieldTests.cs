using Coop.Core.Client.Services.MobileParties.Messages.Fields;
using Coop.IntegrationTests.Environment;
using Coop.IntegrationTests.Environment.Instance;
using GameInterface.Services.Heroes.Messages;
using GameInterface.Services.MobileParties.Messages.Fields.Commands;
using GameInterface.Services.MobileParties.Messages.Fields.Events;

namespace Coop.IntegrationTests.MobileParties;

public class MobilePartyFieldTests
{
    // Creates a test environment with 1 server and 2 clients by default
    private TestEnvironment TestEnvironment { get; } = new();
    
    [Fact]
    public void ServerReceivedLastTimeStampChanged()
    {
        var triggerMessage = new AttachedToChanged("differentId", "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkAttachedToChanged>());

        foreach(EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeAttachedTo>());
        }
    }
    
    [Fact]
    public void ServerReceivedHasUnpaidWagesChanged()
    {
        var triggerMessage = new HasUnpaidWagesChanged(10f, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkHasUnpaidWagesChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeHasUnpaidWages>());
        }
    }

    [Fact]
    public void ServerReceivedLastCalculatedSpeedChanged()
    {
        var triggerMessage = new LastCalculatedSpeedChanged(10.5f, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkLastCalculatedSpeedChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeLastCalculatedSpeed>());
        }
    }

    [Fact]
    public void ServerReceivedDisorganizedUntilTimeChanged()
    {
        var triggerMessage = new DisorganizedUntilTimeChanged(1203203, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkDisorganizedUntilTimeChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeDisorganizedUntilTime>());
        }
    }

    [Fact]
    public void ServerReceivedPartyPureSpeedLastCheckVersionChanged()
    {
        var triggerMessage = new PartyPureSpeedLastCheckVersionChanged(2, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkPartyPureSpeedLastCheckVersionChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangePartyPureSpeedLastCheckVersion>());
        }
    }

    [Fact]
    public void ServerReceivedPartyLastCheckIsPrisonerChanged()
    {
        var triggerMessage = new PartyLastCheckIsPrisonerChanged(true, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkPartyLastCheckIsPrisonerChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangePartyLastCheckIsPrisoner>());
        }
    }

    [Fact]
    public void ServerReceivedLastCalculatedBaseSpeedExplainedChanged()
    {
        var triggerMessage = new LastCalculatedBaseSpeedExplainedChanged(2f, true, "RandomValue", "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkLastCalculatedBaseSpeedExplainedChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeLastCalculatedBaseSpeedExplained>());
        }
    }

    [Fact]
    public void ServerReceivedPartyLastCheckAtNightChanged()
    {
        var triggerMessage = new PartyLastCheckAtNightChanged(true, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkPartyLastCheckAtNightChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangePartyLastCheckAtNight>());
        }
    }

    [Fact]
    public void ServerReceivedItemRosterVersionNoChanged()
    {
        var triggerMessage = new ItemRosterVersionNoChanged(1, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkItemRosterVersionNoChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeItemRosterVersionNo>());
        }
    }

    [Fact]
    public void ServerReceivedPartySizeRatioLastCheckVersionChanged()
    {
        var triggerMessage = new PartySizeRatioLastCheckVersionChanged(3, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkPartySizeRatioLastCheckVersionChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangePartySizeRatioLastCheckVersion>());
        }
    }

    [Fact]
    public void ServerReceivedLatestUsedPaymentRatioChanged()
    {
        var triggerMessage = new LatestUsedPaymentRatioChanged(3, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkLatestUsedPaymentRatioChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeLatestUsedPaymentRatio>());
        }
    }

    [Fact]
    public void ServerReceivedCachedPartySizeRatioChanged()
    {
        var triggerMessage = new CachedPartySizeRatioChanged(1.2f, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkCachedPartySizeRatioChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeCachedPartySizeRatio>());
        }
    }

    [Fact]
    public void ServerReceivedCachedPartySizeLimitChanged()
    {
        var triggerMessage = new CachedPartySizeLimitChanged(100, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkCachedPartySizeLimitChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeCachedPartySizeLimit>());
        }
    }

    [Fact]
    public void ServerReceivedDoNotAttackMainPartyChanged()
    {
        var triggerMessage = new DoNotAttackMainPartyChanged(5, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkDoNotAttackMainPartyChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeDoNotAttackMainParty>());
        }
    }

    [Fact]
    public void ServerReceivedCustomHomeSettlementChanged()
    {
        var triggerMessage = new CustomHomeSettlementChanged("PravenId", "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkCustomHomeSettlementChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeCustomHomeSettlement>());
        }
    }

    [Fact]
    public void ServerReceivedIsDisorganizedChanged()
    {
        var triggerMessage = new IsDisorganizedChanged(true, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkIsDisorganizedChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeIsDisorganized>());
        }
    }

    [Fact]
    public void ServerReceivedIsCurrentlyUsedByAQuestChanged()
    {
        var triggerMessage = new IsCurrentlyUsedByAQuestChanged(true, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkIsCurrentlyUsedByAQuestChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeIsCurrentlyUsedByAQuest>());
        }
    }

    [Fact]
    public void ServerReceivedPartyTradeGoldChanged()
    {
        var triggerMessage = new PartyTradeGoldChanged(500, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkPartyTradeGoldChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangePartyTradeGold>());
        }
    }

    [Fact]
    public void ServerReceivedIgnoredUntilTimeChanged()
    {
        var triggerMessage = new IgnoredUntilTimeChanged(4651321, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkIgnoredUntilTimeChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeIgnoredUntilTime>());
        }
    }

    [Fact]
    public void ServerReceivedAverageFleeTargetDirectionChanged()
    {
        var triggerMessage = new AverageFleeTargetDirectionChanged(1.0f, 2.0f, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkAverageFleeTargetDirectionChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeAverageFleeTargetDirection>());
        }
    }

    [Fact]
    public void ServerReceivedBesiegerCampResetStartedChanged()
    {
        var triggerMessage = new BesiegerCampResetStartedChanged(true, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkBesiegerCampResetStartedChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeBesiegerCampResetStarted>());
        }
    }

    [Fact]
    public void ServerReceivedLastWeatherTerrainEffectChanged()
    {
        var triggerMessage = new LastWeatherTerrainEffectChanged(12, "testId");

        var server = TestEnvironment.Server;

        server.SimulateMessage(this, triggerMessage);

        Assert.Equal(1, server.NetworkSentMessages.GetMessageCount<NetworkLastWeatherTerrainEffectChanged>());

        foreach (EnvironmentInstance client in TestEnvironment.Clients)
        {
            Assert.Equal(1, client.InternalMessages.GetMessageCount<ChangeLastWeatherTerrainEffect>());
        }
    }
}