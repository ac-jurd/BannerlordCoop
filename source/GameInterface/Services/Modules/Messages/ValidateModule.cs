﻿using Common.Messaging;

namespace GameInterface.Services.Modules.Messages
{
    public readonly struct ValidateModules : ICommand
    {

    }

    public readonly struct ModulesValidated : IEvent
    {
    }
}
