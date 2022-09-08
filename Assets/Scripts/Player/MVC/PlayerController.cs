using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;
        private PlayerService playerService;
        public void Start()
        {
            playerService = PlayerService.Instance;
        }

        public void Update()
        {
            
        }
        public void FixedUpdate()
        {
        }
        public PlayerController(PlayerModel _model)
        {
            playerModel = _model;
        }
        public PlayerView PlayerView { get { return playerView; } set { playerView = value; } }
    }
}
