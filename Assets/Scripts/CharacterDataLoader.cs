using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterDataLoader
{
    public string characterStatsAddress;

    public void Load(string address, Action<CharacterDataSO> onLoaded)
    {
        Addressables.LoadAssetAsync<CharacterDataSO>(address).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                onLoaded?.Invoke(handle.Result);
            else
                Debug.LogError($"Failed to load stats from address: {address}");
        };
    }
}
