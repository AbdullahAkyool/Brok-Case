using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public static InteractionHandler Instance { get; private set; }

    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private float interactionDistance = 2f;

    private Transform currentCamera;
    private Transform currentTakePoint;
    public Transform CurrentTakePoint => currentTakePoint;

    private CollectableObject currentCollectedObject;
    public CollectableObject CurrentCollectedObject { get => currentCollectedObject; set => currentCollectedObject = value; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetActiveCharacter(Transform cameraTransform, Transform takePoint)
    {
        currentCamera = cameraTransform;
        currentTakePoint = takePoint;
    }

    private void Update()
    {
        if (currentCamera == null || currentTakePoint == null) return;

        if (Input.GetKeyDown(interactKey))
        {
            Ray ray = new Ray(currentCamera.position, currentCamera.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayerMask))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    if (currentCollectedObject != null && interactable is CollectableObject)
                    {
                        currentCollectedObject.DropObject();
                        currentCollectedObject = null;
                    }

                    interactable.Interact();
                    return;
                }
            }

            if (currentCollectedObject != null)
            {
                currentCollectedObject.DropObject();
                currentCollectedObject = null;
            }
        }
    }
}
