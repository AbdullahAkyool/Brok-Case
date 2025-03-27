using UnityEngine;
using Zenject;

public class CharacterSpawner : MonoBehaviour
{
    [Inject] private CharacterFactory characterFactory;
    [SerializeField] private string prefabAddress = "CharacterData_Cylinder_Prefab";
    [SerializeField] private CharacterDataSO characterData;
    [Inject] private SaveSystem _saveSystem;

    private void Start()
    {
        _saveSystem.Load(characterData);

        characterFactory.CreateCharacter(prefabAddress, null, characterData, character =>
        {
            Debug.Log("Karakter instantiate edildi: " + character.name);

            CharacterUpgradeUI.Instance.UpgradeCharacter(characterData);
        });
    }
}