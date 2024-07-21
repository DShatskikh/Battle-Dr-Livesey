namespace Game
{
    public abstract class Singleton<T> where T : new()
    {
        private static T _object;
        
        public static T GetInstance()
        {
            if (_object == null)
                _object = new T();

            return _object;
        }
    }
}