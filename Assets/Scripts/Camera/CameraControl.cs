using System;
using UnityEngine;

namespace ZombieFPS.Camera
{
    public class CameraControl : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float mouseSensitivity=1000f;
        [SerializeField,Range(0,360)] private float maxRotationAngle=90f;

        private Transform targetTransform;
        private float mouseInputX;
        private float mouseInputY;
        private float xRotation=0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            targetTransform = CameraService.Instance.PlayerTransform;
        }
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            LookAtMouse();
        }

        private void LookAtMouse()
        {
            xRotation -= mouseInputY;
            xRotation = Mathf.Clamp( xRotation,-maxRotationAngle, maxRotationAngle);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            if(targetTransform)
            {
                targetTransform.Rotate(Vector3.up * mouseInputX);
            }
        }
    }
}
