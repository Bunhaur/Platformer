using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 15f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}