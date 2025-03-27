using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    public CinemachineVirtualCamera FpsCamera => fpsCamera;
    [SerializeField] private Transform fpsCameraDefaultPosition;
    public Transform FpsCameraDefaultPosition => fpsCameraDefaultPosition;

    void Awake()
    {
        Instance = this;

        SetCameraPosition(fpsCameraDefaultPosition);
    }

    public void SetCameraPosition(Transform target)
    {
        fpsCamera.transform.SetParent(target);
        fpsCamera.transform.localPosition = Vector3.zero;
        fpsCamera.transform.localRotation =  Quaternion.identity;
    }
}
