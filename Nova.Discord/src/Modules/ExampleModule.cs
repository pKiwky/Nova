using Nova.Discord.Core;
using Serilog;

namespace Nova.Discord.Modules {

    public class ExampleModule : BaseModule {
        public override string ModuleName { get; set; } = "ExampleModule";

        private ILogger _logger;

        public override Task OnModuleLoaded() {
            // Code here...
            return Task.CompletedTask;
        }

        // Override methods here...
    }

}