using Nova.Discord.Core;
using Serilog;

namespace Nova.Discord.Modules {

    public class ExampleModule : BaseModule {
        private ILogger _logger;

        // public ExampleModule(ILogger logger) {
        //     _logger = logger;
        // }

        public override Task OnModuleLoaded() {
            // Code here...
            return Task.CompletedTask;
        }

        // Override methods here...
    }

}