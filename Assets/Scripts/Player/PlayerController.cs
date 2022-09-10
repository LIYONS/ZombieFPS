using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Update()
        {
            movementDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            {
                Jump();
            }
        }
        private void FixedUpdate()
        {
            if(characterController.isGrounded && playerVelocity.y<0)
            {
                playerVelocity.y = 0;
            }
            characterController.Move(movementDir * movementSpeed * Time.fixedDeltaTime);
            playerVelocity.y += gravity * Time.deltaTime ;

            characterController.Move(playerVelocity * Time.deltaTime);

        }
        private void Jump()
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
