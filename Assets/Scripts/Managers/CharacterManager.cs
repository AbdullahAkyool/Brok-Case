using UnityEngine;
using Zenject;

public class CharacterManager : MonoBehaviour
{
    private CharacterDataLoader _loader;

    [Inject]
    public void Construct(CharacterDataLoader loader)
    {
        _loader = loader;
    }

    private void Start()
    {
        _loader.Load("CharacterData_Cube", stats =>
       {
           Debug.Log($"[CharacterManager] Yürüme: {stats.walkSpeed}");
       });
    }
}
