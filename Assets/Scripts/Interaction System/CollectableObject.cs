using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour, IInteractable
{
    protected Transform currentHolder;
    private Rigidbody rb;
    private Collider clldr;
    [SerializeField] float throwForce = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        clldr = GetComponent<Collider>();
    }
    public void Interact()
    {
        if (InteractionHandler.Instance.CurrentCollectedObject != null) return;

        TakeObject(InteractionHandler.Instance.CurrentTakePoint);
    }

    public virtual void TakeObject(Transform holder)
    {
        if (holder == null) return;

        currentHolder = holder;
        transform.SetParent(currentHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GetRigirdBody().isKinematic = true;
        clldr.enabled = false;

        InteractionHandler.Instance.CurrentCollectedObject = this;
    }

    public virtual void DropObject()
    {
        transform.SetParent(null);

        Rigidbody rb = GetRigirdBody();
        rb.isKinematic = false;
        rb.velocity = Vector3.zero; 

        Vector3 throwDir = InteractionHandler.Instance.CurrentTakePoint.forward + Vector3.up * 0.2f;
        GetRigirdBody().AddForce(throwDir.normalized * throwForce, ForceMode.VelocityChange);

        clldr.enabled = true;
        currentHolder = null;
    }

    public Rigidbody GetRigirdBody()
    {
        if (rb != null)
        {
            return rb;
        }
        else
        {
            rb = gameObject.AddComponent<Rigidbody>();
            return rb;
        }
    }
}
