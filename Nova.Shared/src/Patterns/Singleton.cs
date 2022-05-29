namespace Nova.Shared.Patterns {

    public abstract class Singleton<T> where T : Singleton<T>, new() {
        private static object _locker = new object();
        private static T? _instance;

        public static T Instance() {
            if (_instance == null) {
                lock (_locker) {
                    if (_instance == null) {
                        _instance = new T();
                    }
                }
            }

            return _instance;
        }
    }

}