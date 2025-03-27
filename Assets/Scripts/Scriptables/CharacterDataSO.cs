using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character Data")]
public class CharacterDataSO : ScriptableObject
{
    public string characterId;
    public string characterAddress;
    public float walkSpeed;
    public float runSpeed;
    public float jumpPower;
    public Sprite characterIcon;
}
