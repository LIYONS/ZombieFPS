using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;

namespace ZombieFPS.Services
{
    public class PlayerService : MonoSIngletonGeneric<PlayerService>
    {
        public Transform playerTransform { get; set; }

    }
}
