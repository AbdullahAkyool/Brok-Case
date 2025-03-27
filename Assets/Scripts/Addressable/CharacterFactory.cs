using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using System;

public class CharacterFactory
{
    private readonly DiContainer _container;

    public CharacterFactory(DiContainer container)
    {
        _container = container;
    }

    public void CreateCharacter(string prefabAddress, Transform parent, CharacterDataSO dataSO, Action<GameObject> onCreated)
    {
        Addressables.InstantiateAsync(prefabAddress, parent).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject character = handle.Result;

                // CharacterMovementController’a Init() ile veriyi gönder
                var controller = character.GetComponent<CharacterMovementController>();
                if (controller != null)
                {
                    controller.Init(dataSO);
                }

                onCreated?.Invoke(character);
            }
            else
            {
                Debug.LogError("Karakter prefab yüklenemedi!");
            }
        };
    }

}
