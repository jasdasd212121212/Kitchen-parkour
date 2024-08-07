using UnityEngine;

public class CoinEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _collectSound;
    [SerializeField] private ParticleSystem _collectParticle;

    [Space()]

    [SerializeField][Min(0.1f)] private float _lifetimeAfterPlayeing = 1f;

    public void Play()
    {
        transform.SetParent(null);

        _collectSound.Play();
        _collectParticle.Play();

        Invoke(nameof(Deactivate), _lifetimeAfterPlayeing);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}