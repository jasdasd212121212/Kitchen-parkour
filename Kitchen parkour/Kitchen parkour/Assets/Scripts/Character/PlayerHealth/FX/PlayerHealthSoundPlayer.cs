using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerHealthSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _deadSounds;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();

        _playerHealth.OnDead += PlayDeadSound;
    }

    private void OnDestroy()
    {
        _playerHealth.OnDead -= PlayDeadSound;
    }

    private void PlayDeadSound()
    {
        _deadSounds.Play();
    }
}