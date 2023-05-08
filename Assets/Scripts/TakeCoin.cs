using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] Score _score;
    [SerializeField] AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Remove();
            _audioSource.Play();
            _score.AddScore();
        }
    }
}