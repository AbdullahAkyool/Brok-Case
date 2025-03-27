using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFixedUpdateManager : MonoBehaviour
{
    public static event Action OnUpdateEvent;
    public static event Action OnFixedUpdateEvent;
    public static event Action OnLateUpdateEvent;

    void Update()
    {
        OnUpdateEvent?.Invoke();
    }

    void FixedUpdate()
    {
        OnFixedUpdateEvent?.Invoke();
    }

    void LateUpdate()
    {
        OnLateUpdateEvent?.Invoke();
    }
}
