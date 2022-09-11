using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;

namespace ZombieFPS.Services
{
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public Transform playerTransform { get; set; }

    }
}
