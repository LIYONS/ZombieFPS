using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;

namespace ZombieFPS
{
    public class EventHandler : MonoSingletonGeneric<EventHandler>
    {
        public event Action OnGameOver;

        public event Action OnGamePaused;

        public event Action OnEnemyDead;

        public void InvokeOnGameOver()
        {
            OnGameOver?.Invoke();
        }

        public void InvokeOnGamePaused()
        {
            OnGamePaused?.Invoke();
        }

        public void InvokeOnEnemyDead()
        {
            OnEnemyDead?.Invoke();
        }
    }
}
