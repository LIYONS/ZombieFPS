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
            targetTransform = CameraService.Instance.GetPlayerTransform;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void LateUpdate()
        {
            LookAtMouse();
        }

        private void LookAtMouse()
        {
            mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity*Time.deltaTime;
            mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseInputY;
            xRotation = Mathf.Clamp( xRotation,-maxRotationAngle, maxRotationAngle);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            targetTransform.Rotate(Vector3.up * mouseInputX);
        }
    }
}
