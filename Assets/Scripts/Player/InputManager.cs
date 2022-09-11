using UnityEngine;

namespace ZombieFPS.Player
{
    public class InputManager : MonoBehaviour
    {
        private PlayerController playerController;
        private WeaponController weaponController;

        private float horizontal;
        private float vertical;
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
        private void FixedUpdate()
        {
            playerController.Movement(horizontal, vertical);
        }
        private void MovementCheck()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
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
