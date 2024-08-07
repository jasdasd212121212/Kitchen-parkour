using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlayerHitBox : MonoBehaviour
{
    public event Action OnKilled;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SignatureMarcup_Ground>() != null)
        {
            OnKilled?.Invoke();
        }
    }
}