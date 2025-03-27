using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    static Tween doorTween;
    public bool isOpen = false;
    public void Interact()
    {
        DoorToggle();
    }

    public void DoorToggle()
    {
        if (doorTween != null)
        {
            doorTween.Kill();
        }

        if (isOpen)
        {
            doorTween = transform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
        }
        else
        {
            doorTween = transform.DOLocalRotate(new Vector3(0, 90, 0), 1f);
        }
        isOpen = !isOpen;
    }
}
