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

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleInput();
        }
        private void FixedUpdate()
        {
            if(characterController.isGrounded && movementDir.y<0)
            {
                movementDir.y = 0;
            }
            movementDir.y += gravity * Time.deltaTime;
            MoveMent();
        }
        private void HandleInput()
        {
            movementDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            {
                Jump();
            }
        }
        private void Jump()
        {
            movementDir.y += Mathf.Sqrt(jumpHeight*-2f*gravity);
        }
        private void MoveMent()
        {
            characterController.Move(movementDir*movementSpeed*Time.fixedDeltaTime);
        }
    }
}
