using UnityEngine;

namespace ZombieFPS.Singleton
{
    public class MonoSIngletonGeneric<T> : MonoBehaviour where T:MonoSIngletonGeneric<T>
    {
        private static T instance;

        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if(instance)
            {
                Destroy(this);
            }
            else
            {
                instance = (T)this;
            }
        }
    }
}
