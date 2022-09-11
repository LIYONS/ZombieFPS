using UnityEngine;

namespace ZombieFPS.Singleton
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T:MonoSingletonGeneric<T>
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
