using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(JumpController))]
[RequireComponent(typeof(InputService))]

public class PlayerController : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private MovementController _movementController;
    private JumpController _jumpController;
    private InputService _inputService;

    private float _horizontal;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _jumpController = GetComponent<JumpController>();
        _inputService = GetComponent<InputService>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        _horizontal = _inputService.GetHorizontal();
        _movementController.Move(_horizontal);
    }

    private void Flip()
    {
        if (_horizontal != 0)
            _movementController.FlipSprite(_horizontal);
    }

    private void Jump()
    {
        if (_inputService.IsPushJump() == true)
            _jumpController.Jump();
    }
}