using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMovementStrategy
{
    void Move(Transform transform, Vector3 input, CharacterDataSO stats);
    void Sprint(Transform transform, Vector3 input, CharacterDataSO stats);
    void Jump(Rigidbody rb, CharacterDataSO stats);
}
