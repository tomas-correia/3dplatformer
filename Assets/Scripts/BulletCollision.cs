using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet is colliding with the player
        if (other.CompareTag("Player"))
        {
            // If it's the player, don't destroy the bullet
            return;
        }
        Destroy(gameObject);
    }
}
