using UnityEngine;
using System.Collections;

public class BoomCandy : MonoBehaviour
{
    public float explosionRadius = 3f;
    public float explosionForce = 700f;
    public GameObject explosionEffect;

    private bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded ) 
        {
            hasExploded = true;
            StartCoroutine(DelayedExplosion(1f)); 
        }
    }

    IEnumerator DelayedExplosion(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();
    }

    void Explode()
    {
        // Explore Effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Find all colliders within the explosion radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearby in hitColliders)
        {
            // Check if it's "Candy" or "BoomCandy" and not the BoomCandy itself
            if (nearby.gameObject.CompareTag("Candy") || nearby.gameObject.CompareTag("GoldCandy") && nearby.gameObject != this.gameObject)
            {
                // Apply explosion force if it has a Rigidbody
                Rigidbody rb = nearby.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                // Destroy the candy
                Destroy(nearby.gameObject);
            }
        }

        // Destroy the BoomCandy after the explosion
        Destroy(gameObject);
    }
}
