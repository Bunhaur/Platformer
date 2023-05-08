using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Patrolling : MonoBehaviour
{
    [SerializeField] Transform _path;

    private SpriteRenderer _renderer;

    private float _speed;
    private Transform[] _points;
    private int _current;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _speed = 3f;

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_current].position, _speed * Time.deltaTime);

        if (transform.position == _points[_current].position )
            _current++;

        if (_current >= _points.Length)
            _current = 0;
        
        if (_current == 0)
            _renderer.flipX = true;
        else
            _renderer.flipX = false;
    }
}
