using System.Collections;
using UnityEngine;

public class BallParticles : MonoBehaviour
{
    public ParticleSystem ballParticles;
    public float cooldownTime = 0.01f; // time between particle activations
    public float groundVelocityThreshold = 0.05f; // how small vertical speed must be to count as "grounded"
    public float checkDelay = 0.1f; // how often to check for ground contact

    private Rigidbody rb;
    private bool canPlayParticles = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the vertical velocity is near zero (not going up or down)
        bool onGround = Mathf.Abs(rb.linearVelocity.y) < groundVelocityThreshold;

        // Optional: also check if it's *resting* (almost no horizontal movement)
        // bool resting = rb.velocity.magnitude < 0.1f;

        if (onGround && canPlayParticles)
        {
            StartCoroutine(PlayParticlesWithCooldown());
        }
    }

    private IEnumerator PlayParticlesWithCooldown()
    {
        canPlayParticles = false;

        ballParticles.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        ballParticles.Play();

        yield return new WaitForSeconds(cooldownTime);
        canPlayParticles = true;
    }
}
