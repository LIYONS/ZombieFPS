using UnityEngine;
using ZombieFPS.Services;

namespace ZombieFPS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity = -9.81f;

        private CharacterController characterController;
        private Vector3 movementDir;
        private Vector3 playerVelocity;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            PlayerService.Instance.playerTransform = this.transform;
        }

        public void Movement(float horizontal,float vertical)
        {
            movementDir = transform.right * horizontal + transform.forward * vertical;
            if (characterController.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0;
            }
            characterController.Move(movementDir * movementSpeed * Time.fixedDeltaTime);
            playerVelocity.y += gravity * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }

        public void Jump()
        {
            if (characterController.isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
    }
}
