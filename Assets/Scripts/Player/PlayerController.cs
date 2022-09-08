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


        private CharacterController characterController;
        private float horizontal;
        private float vertical;
        private Vector3 movementDir;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            PlayerService.Instance.PlayerTransform = this.transform;
        }

        private void Update()
        {
            HandleInput();
        }
        private void FixedUpdate()
        {
            if (!characterController.isGrounded)
            {
                GravityControl();
            }
            MoveMent();
        }
        private void HandleInput()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }
        private void  GravityControl()
        {
            Vector3 moveVector = Vector3.zero;
            moveVector += Physics.gravity;
            characterController.Move(moveVector*Time.fixedDeltaTime);
        }
        private void MoveMent()
        {
            movementDir = transform.right * horizontal + transform.forward * vertical;
            characterController.Move(movementDir*movementSpeed*Time.fixedDeltaTime);
        }
    }
}
