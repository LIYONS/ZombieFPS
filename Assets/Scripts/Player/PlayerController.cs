using UnityEngine;
using ZombieFPS.Services;

namespace ZombieFPS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity;

        [Header("Look Parameters")]
        [SerializeField, Range(1, 10)] private float lookSpeed;
        [SerializeField, Range(0, 180)] private float upperLookLimit;
        [SerializeField, Range(0, 180)] private float lowerLookLimit;
        [SerializeField] private GameObject fpsCharacter;

        private CharacterController characterController;
        private InputManager inputManager;
        private Vector3 moveDirection;
        private Vector2 currentInput;
        private float moveDirectionY;
        private float rotationX;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputManager = GetComponent<InputManager>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnEnable()
        {
            PlayerService.Instance.playerTransform = this.transform;
        }
        private void Update()
        {
            HandleMovementInput();
            HandleCameraLook();
            ApplyMovement();
        }

        public void HandleMovementInput()
        {
            currentInput = new Vector2(walkSpeed * inputManager.Vertical, walkSpeed * inputManager.Horizontal);
            moveDirectionY = moveDirection.y;
            moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
            moveDirection.y = moveDirectionY;          
        }

        private void HandleCameraLook()
        {
            rotationX -= inputManager.MouseY * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
            fpsCharacter.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * inputManager.MouseX * lookSpeed);
        }
        public void Jump()
        {
            if(characterController.isGrounded)
            {
                moveDirection.y = jumpForce;
            }
        }

        private void ApplyMovement()
        {
            if(! characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
