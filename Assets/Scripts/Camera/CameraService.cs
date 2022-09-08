using UnityEngine;
using ZombieFPS.Singleton;
using ZombieFPS.Player;

namespace ZombieFPS.Camera
{
    public class CameraService : MonoSIngletonGeneric<CameraService>
    {
        private PlayerService playerService;
        protected override void Awake()
        {
            base.Awake();
            playerService = PlayerService.Instance;
        }

        public Transform PlayerTransform { get { return playerService.PlayerTransform; } }
    }
}
