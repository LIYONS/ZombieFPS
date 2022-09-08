using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;

namespace ZombieFPS.Player
{
    public class PlayerService : MonoSIngletonGeneric<PlayerService>
    {
        [SerializeField] private Transform playerTransform;

        public Transform GetPlayerTransform { get { return playerTransform; } }
    }
}
