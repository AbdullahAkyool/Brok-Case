using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterDataSO : ScriptableObject
{
    public string characterId;
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
}
