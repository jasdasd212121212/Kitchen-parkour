using UnityEngine;

public class JumperSoundPlayer : MonoBehaviour
{
    [SerializeField] private PlayerJumper _player;
    [SerializeField] private AudioSource _jumpSound;

    private void Start()
    {
        _player.OnJump += PlayJumpSound;
    }

    private void OnDestroy()
    {
        _player.OnJump -= PlayJumpSound;
    }

    private void PlayJumpSound()
    {
        _jumpSound.Play();
    }
}