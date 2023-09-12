using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Scripts.Infrastructure.GameCore.States.SetupState
{
    public class HandlerSetupLevelContainer : IHandlerSetupLevel
    {
        private readonly List<IHandlerSetupLevel> _handlers;

        public HandlerSetupLevelContainer(IEnumerable<IHandlerSetupLevel> handlerSetupLevels)
        {
            _handlers = handlerSetupLevels.ToList();
        }

        public async Task Process()
        {
            foreach (var handler in _handlers) await handler.Process();
        }
    }
}