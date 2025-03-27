using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtest : MonoBehaviour
{
    public string characterStatsAddress = "CharacterData_Capsule"; // Addressables'da verdiğin isim

    private void Start()
    {
        CharacterDataLoader loader = new CharacterDataLoader();
        loader.characterStatsAddress = characterStatsAddress;
        loader.Load(characterStatsAddress, stats =>
        {
            Debug.Log($"Yüklenen karakter: {stats.characterId}");
            Debug.Log($"Yürüme hızı: {stats.walkSpeed}");
            Debug.Log($"Koşma hızı: {stats.runSpeed}");
            Debug.Log($"Zıplama gücü: {stats.jumpPower}");
        });
    }
}
