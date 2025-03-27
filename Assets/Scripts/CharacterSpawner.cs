using UnityEngine;
using Zenject;

public class CharacterSpawner : MonoBehaviour
{
    [Inject] private CharacterFactory characterFactory;

    [SerializeField] private string prefabAddress = "CharacterData_Cylinder_Prefab";

    [SerializeField] private CharacterDataSO characterData;

    private void Start()
    {
        characterFactory.CreateCharacter(prefabAddress, null, characterData, character =>
        {
            Debug.Log("Karakter instantiate edildi: " + character.name);

            CharacterUpgradeUI.Instance.UpgradeCharacter(characterData);
        });
    }
}