using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerController : MonoBehaviour
    {
        private void Awake()
        {
            PlayerService.Instance.PlayerTransform = this.transform;
        }
    }
}
