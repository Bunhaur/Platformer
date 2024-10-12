using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(InputService))]
public class Player : MonoBehaviour
{
    private PlayerMovement _movementController;
    private Jumper _jumpController;
    private InputService _inputService;
    private Wallet _wallet;
    private float _horizontal;

    private void Awake()
    {
        _movementController = GetComponent<PlayerMovement>();
        _jumpController = GetComponent<Jumper>();
        _inputService = GetComponent<InputService>();
        _wallet = GetComponent<Wallet>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin(coin.Price);
            coin.Remove();
        }
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