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
        [SerializeField] private Transform fpsCharacter;

        [Header("Head Bob")]
        [SerializeField] private float bobSpeed; 
        [SerializeField] private float bobAmount;

        [Header("Music")]
        [SerializeField] private AudioSource musicAs;

        private CharacterController characterController;
        private InputManager inputManager;
        private Vector3 moveDirection;
        private Vector2 currentInput;
        private float moveDirectionY;
        private float rotationX;
        private float defaultYPos;
        private float timer;
        private bool isGamePaused;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputManager = GetComponent<InputManager>();
            defaultYPos = fpsCharacter.transform.localPosition.y;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnEnable()
        {
            PlayerService.Instance.playerTransform = this.transform;
            EventHandler.Instance.OnGamePaused += OnGamePaused;
            EventHandler.Instance.OnGameResumed += OnGameResumed;
        }
        private void Update()
        {
            HandleMovementInput();
            HandleCameraLook();
            HandleHeadbob();
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
            if (!isGamePaused)
            {
                rotationX -= inputManager.MouseY * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
                fpsCharacter.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
                transform.Rotate(Vector3.up * inputManager.MouseX * lookSpeed);
            }
        }
        private void HandleHeadbob()
        {
            if(!characterController.isGrounded)
            {
                return;
            }
            if(Mathf.Abs(moveDirection.x)>0.1f || Mathf.Abs(moveDirection.z)>0.1f)
            {
                timer += Time.deltaTime * bobSpeed;
                fpsCharacter.transform.localPosition = new Vector3(
                    fpsCharacter.transform.localPosition.x,
                    defaultYPos+Mathf.Sin(timer)*bobAmount,
                    fpsCharacter.transform.localPosition.z
                    );
            }
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
            if (!isGamePaused)
            {
                if (!characterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }
                characterController.Move(moveDirection * Time.deltaTime);
            }
        }

        private void OnGamePaused()
        {
            isGamePaused = true;
            musicAs.Stop();
        }
        private void OnGameResumed()
        {
            isGamePaused = false;
            musicAs.Play();
        }
    }
}
