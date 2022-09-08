using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerModel
    {
        private PlayerController playerController;

        public PlayerController Controller { get { return playerController; } set { playerController = value; } }
    }
}
