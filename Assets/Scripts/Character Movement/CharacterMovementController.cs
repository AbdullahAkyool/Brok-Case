using UnityEngine;
using Zenject;

public class CharacterMovementController : MonoBehaviour
{
    [Inject] private CharacterDataSO data;
    private ICharacterMovementStrategy _movementStrategy;

    private Rigidbody _rb;

    private void Awake()
    {
        _movementStrategy = new BasicMovementStrategy(); // ileride farklı stratejilerle değiştirebiliriz
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _movementStrategy.Move(transform, input, data);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movementStrategy.Jump(_rb, data);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementStrategy.Sprint(transform, input, data);
        }
    }
}
