using UnityEngine;

public class Coin : MonoBehaviour
{
    public readonly int Price = 1;

    public void Remove()
    {
        Destroy(gameObject);
    }
}