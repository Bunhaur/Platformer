using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(JumpController))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerController : MonoBehaviour
{
    private MovementController _movementController;
    private JumpController _jumpController;
    private SpriteRenderer _spriteRenderer;

    private float _horizontal;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _jumpController = GetComponent<JumpController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleInput();
        _jumpController.Jump();
        _movementController.FlipSprite(_spriteRenderer, _horizontal);
    }

    private void FixedUpdate()
    {
        _movementController.Move(_horizontal);
    }

    private void HandleInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }
}