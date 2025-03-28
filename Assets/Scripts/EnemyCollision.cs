using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private int health = 100;
    private Renderer[] meshRenderers;
    private Color originalColor;

    void Start()
    {
        // Get all Renderer components from the current object and its children
        meshRenderers = GetComponentsInChildren<Renderer>();

        // Store the original color of the first Renderer component
        if (meshRenderers.Length > 0)
        {
            originalColor = meshRenderers[0].material.color;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        TintRed();

        if (health > 0)
        {
            health -= 10;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void TintRed()
    {
        // Iterate through all meshRenderers and tint each one red
        foreach (var renderer in meshRenderers)
        {
            renderer.material.color = Color.red;
        }

        // Reset the color after a short delay
        Invoke(nameof(ResetColor), 0.1f);
    }

    void ResetColor()
    {
        // Reset the color of all meshRenderers to the original color
        foreach (var renderer in meshRenderers)
        {
            renderer.material.color = originalColor;
        }
    }
}
