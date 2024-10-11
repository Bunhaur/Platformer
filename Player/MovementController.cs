using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontal)
    {
        _velocity = _rigidbody.velocity;
        _velocity.x = horizontal * _speed;
        _rigidbody.velocity = _velocity;
    }

    public void FlipSprite(SpriteRenderer spriteRenderer, float horizontal)
    {
        if (horizontal != 0)
            spriteRenderer.flipX = horizontal < 0;
    }
}