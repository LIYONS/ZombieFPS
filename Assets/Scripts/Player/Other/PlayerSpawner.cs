using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieFPS.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;

        private Transform playerTransform;

        public Transform PlayerTransform { get { return playerTransform; } }

        private void Awake()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            PlayerModel playerModel = new();
            PlayerController playerController = new(playerModel);
            playerModel.Controller=playerController;
            PlayerView playerView = Instantiate(playerPrefab, transform.position, transform.rotation).GetComponent<PlayerView>();
            playerTransform = playerView.transform;
            playerController.PlayerView = playerView;
            playerView.Controller = playerController;
        }
    }
}
