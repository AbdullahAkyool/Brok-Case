using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private CharacterDataSO data;
    private ICharacterMovementStrategy _movementStrategy;
    private Rigidbody _rb;

    public void Init(CharacterDataSO injectedData)
    {
        data = injectedData;
    }

    private void Awake()
    {
        _movementStrategy = new BasicMovementStrategy();
        _rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        UpdateFixedUpdateManager.OnUpdateEvent += CharacterMovement;
    }

    void OnDisable()
    {
        UpdateFixedUpdateManager.OnUpdateEvent -= CharacterMovement;
    }

    private void CharacterMovement()
    {
        if (data == null)
        {
            Debug.LogError(">>> CharacterDataSO verilmemiş!");
            return;
        }

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
