using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private CharacterUpgradeUI characterUpgradeUI;
    private InteractionHandler interactionHandler;
    private CameraManager cameraManager;

    [Inject]
    private CharacterFactory characterFactory;

    [SerializeField] private GameObject currentCharacter;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        characterUpgradeUI = CharacterUpgradeUI.Instance;
        interactionHandler = InteractionHandler.Instance;
        cameraManager = CameraManager.Instance;
    }

    public void SpawnCharacter(CharacterDataSO characterData)
    {
        if (currentCharacter != null)
        {
            cameraManager.SetCameraPosition(cameraManager.FpsCameraDefaultPosition);

            if(interactionHandler.CurrentCollectedObject != null)
            {
                interactionHandler.CurrentCollectedObject.DropObject();
            }

            Destroy(currentCharacter);
        }

        characterFactory.CreateCharacter(characterData.characterAddress, null, characterData, character =>
        {
            currentCharacter = character;

            var lookController = character.GetComponent<FPSCameraController>();

            if (lookController != null)
            {
                lookController.Init();
            }

            characterUpgradeUI.UpgradeCharacter(characterData);
        });
    }
}
