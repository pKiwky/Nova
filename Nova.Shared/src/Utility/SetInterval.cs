namespace Nova.Shared.Utility {

    public class SetInterval {
        private readonly Action _action;
        private readonly int _delay;

        public SetInterval(Action action, int delay) {
            _action = action;
            _delay = delay;
        }

        public async void Run() {
            await Task.Delay(_delay);
            _action.Invoke();
        }
    }

}