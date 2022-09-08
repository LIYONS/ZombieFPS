using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        private void Start()
        {
            playerController.Start();
        }
        private void Update()
        {
            playerController.Update();
        }
        private void FixedUpdate()
        {
            playerController.FixedUpdate();
        }
        public PlayerController Controller { get { return playerController; } set { playerController = value; } }
    }
}
