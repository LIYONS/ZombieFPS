using UnityEngine;
using ZombieFPS.Singleton;
using ZombieFPS.Player;

namespace ZombieFPS.Camera
{
    public class CameraService : MonoSIngletonGeneric<CameraService>
    {
        private PlayerService playerService;

        private void Start()
        {
            playerService = PlayerService.Instance;
        }

        public Transform GetPlayerTransform { get { return playerService.GetPlayerTransform; } }
    }
}
