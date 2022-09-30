using System;
using ZombieFPS.Singleton;

namespace ZombieFPS
{
    public class EventHandler : MonoSingletonGeneric<EventHandler>
    {
        public event Action OnGameOver;

        public event Action OnGamePaused;

        public event Action OnEnemyDead;

        public event Action<float> OnPlayerTookDamage;

        public event Action OnGameResumed;

        public void InvokeOnGameOver()
        {
            OnGameOver?.Invoke();
        }

        public void InvokeOnGamePaused()
        {
            OnGamePaused?.Invoke();
        }

        public void InvokeOnGameResumed()
        {
            OnGameResumed?.Invoke();
        }
        public void InvokeOnEnemyDead()
        {
            OnEnemyDead?.Invoke();
        }

        public void InvokePlayerDamaged(float amount)
        {
            OnPlayerTookDamage?.Invoke(amount);
        }
    }
}
