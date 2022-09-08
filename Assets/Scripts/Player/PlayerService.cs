using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieFPS.Singleton;

namespace ZombieFPS.Player
{
    public class PlayerService : MonoSIngletonGeneric<PlayerService>
    {
        public Transform PlayerTransform { get; set; }
    }
}
