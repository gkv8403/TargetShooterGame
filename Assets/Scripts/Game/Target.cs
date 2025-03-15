using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    public static event Action<Target> OnTargetHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Trigger event
            OnTargetHit?.Invoke(this);

            // Destroy target and projectile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
