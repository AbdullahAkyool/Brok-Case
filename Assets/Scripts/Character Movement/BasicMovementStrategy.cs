using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementStrategy : ICharacterMovementStrategy
{
    public void Move(Transform transform, Vector3 input, CharacterDataSO stats)
    {
        Vector3 movement = new Vector3(input.x, 0f, input.z) * stats.walkSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    public void Sprint(Transform transform, Vector3 input, CharacterDataSO stats)
    {
        Vector3 movement = new Vector3(input.x, 0f, input.z) * stats.runSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    public void Jump(Rigidbody rb, CharacterDataSO stats)
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f) // sadece yerdeyse
        {
            rb.AddForce(Vector3.up * stats.jumpPower, ForceMode.Impulse);
        }
    }
}
