using Cinemachine;
using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private CharacterUpgradeUI characterUpgradeUI;
    private InteractionHandler interactionHandler;

    [Inject]
    private CharacterFactory characterFactory;

    [SerializeField] private GameObject currentCharacter;
    [SerializeField] private CinemachineVirtualCamera fpsCamera;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        characterUpgradeUI = CharacterUpgradeUI.Instance;
        interactionHandler = InteractionHandler.Instance;
    }

    public void SpawnCharacter(CharacterDataSO characterData)
    {
        if (currentCharacter != null)
        {
            fpsCamera.transform.SetParent(null);

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
                lookController.Init(fpsCamera);
            }

            characterUpgradeUI.UpgradeCharacter(characterData);
        });
    }
}
