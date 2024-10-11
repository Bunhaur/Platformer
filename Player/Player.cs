using UnityEngine;

[RequireComponent(typeof(Wallet))]

public class Player : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin(coin.Price);
            coin.Remove();
        }
    }
}