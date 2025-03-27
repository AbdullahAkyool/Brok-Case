using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CharacterDataLoader : MonoBehaviour
{
    public string characterStatsAddress;

    public void LoadCharacterStats(Action<CharacterDataSO> onLoaded)
    {
        Addressables.LoadAssetAsync<CharacterDataSO>(characterStatsAddress).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                onLoaded?.Invoke(handle.Result);
            }
            else
            {
                Debug.LogError($"'{characterStatsAddress}' loading fail.");
            }
        };
    }
}
