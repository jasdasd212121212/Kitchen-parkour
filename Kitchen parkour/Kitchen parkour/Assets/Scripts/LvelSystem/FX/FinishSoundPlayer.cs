using UnityEngine;

[RequireComponent(typeof(FinishTrigger))]
public class FinishSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _finishSound;

    private FinishTrigger _finish;
    private bool _isPlayed;

    private void Start()
    {
        _finish = GetComponent<FinishTrigger>();

        _finish.OnFinished += PlayFinishSound;

        _isPlayed = false;
    }

    private void OnDestroy()
    {
        _finish.OnFinished -= PlayFinishSound;
    }

    private void PlayFinishSound()
    {
        if (_finishSound.isPlaying == false && _isPlayed == false)
        {
            _finishSound.Play();
            _isPlayed = true;
        }
    }
}