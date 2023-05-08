using System.Collections;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _spawns;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawns.childCount];

        for (int i = 0; i < _spawns.childCount; i++)
        {
            _points[i] = _spawns.GetChild(i).transform;
            CreateCoin(_points[i]);
        }
    }

    private void CreateCoin(Transform point)
    {
        Instantiate(_coin, point);
    }
}
