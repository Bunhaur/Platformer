using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float _speed;
    private int _hashAnimationRun;
    private int _hashAnimatioJump;
    private bool _isGround;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _hashAnimationRun = Animator.StringToHash("isRun");
        _hashAnimatioJump = Animator.StringToHash("isJump");

        _speed = 3f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool(_hashAnimationRun, true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _animator.SetBool(_hashAnimationRun, false);
        }

        if (Input.GetKey(KeyCode.W) && _isGround)
        {
            _isGround = false;
            _animator.SetBool(_hashAnimatioJump, true);
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D()
    {
        _animator.SetBool(_hashAnimatioJump, false);
        _isGround = true;
    }
}