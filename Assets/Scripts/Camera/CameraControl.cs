using System;
using UnityEngine;

namespace ZombieFPS.Camera
{
    public class CameraControl : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float mouseSensitivity;
        [SerializeField,Range(0,360)] private float maxRotationAngle=90f;

        private Transform targetTransform;
        private float mouseInputX=0f;
        private float mouseInputY=0f;
        private float xRotation=0f;

        private void Start()
        {
            if(CameraService.Instance==null)
            {
                Debug.Log("Null");
            }
            targetTransform = CameraService.Instance.PlayerTransform;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Update()
        {
            HandleInput();
        }

        private void FixedUpdate()
        {
            LookAtMouse();
        }
        private void HandleInput()
        {
            mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
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
