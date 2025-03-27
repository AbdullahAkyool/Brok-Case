using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [Inject]
    private CharacterFactory characterFactory;

    private GameObject currentCharacter;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnCharacter(CharacterDataSO characterData)
    {
        if (currentCharacter != null)
            Destroy(currentCharacter);

        characterFactory.CreateCharacter(characterData.characterAddress, null, characterData, character =>
        {
            currentCharacter = character;
        });

        CharacterUpgradeUI.Instance.UpgradeCharacter(characterData);
    }
}
