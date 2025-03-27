using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform itemHoldPoint;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float minVerticalAngle = -60f;
    [SerializeField] private float maxVerticalAngle = 60f;

    private float xRotation = 0f;

    public void Init()
    {
        CameraManager.Instance.SetCameraPosition(cameraHolder);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Transform cam = GetCameraTransform();
        Transform takePoint = GetTakePoint();

        InteractionHandler.Instance.SetActiveCharacter(cam, takePoint);
    }

    void OnEnable()
    {
        UpdateFixedUpdateManager.OnUpdateEvent += CharacterRotation;
    }

    void OnDisable()
    {
        UpdateFixedUpdateManager.OnUpdateEvent -= CharacterRotation;
    }

    private void CharacterRotation()
    {
        if (cameraHolder == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        this.transform.Rotate(Vector3.up * mouseX);
    }

    public Transform GetCameraTransform() => cameraHolder;
    public Transform GetTakePoint() => itemHoldPoint;
}
