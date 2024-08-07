using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public event Action OnFinished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SignatureMarcup_Player>() != null)
        {
            OnFinished?.Invoke();
        }
    }
}