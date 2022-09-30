using UnityEngine;

namespace ZombieFPS.Player
{
    public class InputManager : MonoBehaviour
    {
        private PlayerController playerController;
        private WeaponController weaponController;

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            weaponController = GetComponent<WeaponController>();
        }

        private void Update()
        {
            MovementCheck();
            JumpCheck();
            FireCheck();
        }
        private void MovementCheck()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
        }

        private void JumpCheck()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerController.Jump();
            }
        }

        private void FireCheck()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                weaponController.Fire();
            }
        }

    }
}
