using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;
using ZombieFPS.Camera;

namespace ZombieFPS.Player
{
    public class PlayerService : MonoSIngletonGeneric<PlayerService>
    {
        private PlayerSpawner playerSpawner;
        protected override void Awake()
        {
            base.Awake();
            playerSpawner = GetComponent<PlayerSpawner>();
        }

        public Transform PlayerTransform { get { return playerSpawner.PlayerTransform; } }
    }
}
