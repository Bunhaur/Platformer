using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Vector2[] _spawnPoints;
    [SerializeField] Coin _prefab;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        Coin coin;

        foreach (Vector2 point in _spawnPoints)
            coin = Instantiate(_prefab, point, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float size = .5f;

        foreach (Vector2 point in _spawnPoints)
            Gizmos.DrawSphere(point, size);
    }
}