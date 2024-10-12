using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Vector3[] _way;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _point;
    private int _index;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        SetPoint(_index);
    }

    private void Update()
    {
        Move();
    }

    private void SetPoint(int index)
    {
        _point = _way[index];
    }

    private void Move()
    {
        if (transform.position == _point)
        {
            _index = ++_index % _way.Length;

            SetPoint(_index);
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, _point, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = (transform.position.x < _point.x);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        float size = .5f;

        foreach (Vector3 point in _way)
            Gizmos.DrawSphere(point, size);
    }
}