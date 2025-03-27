using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
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

                // Zenject ile stat enjekte et
                _container.Bind<CharacterDataSO>().FromInstance(dataSO).AsSingle().NonLazy();
                _container.InjectGameObject(character);

                onCreated?.Invoke(character);
            }
            else
            {
                Debug.LogError("Karakter prefab yüklenemedi!");
            }
        };
    }
}
