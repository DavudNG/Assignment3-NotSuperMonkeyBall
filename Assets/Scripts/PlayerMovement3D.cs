using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement3D : MonoBehaviour
{
    [Tooltip("Impulse strength applied upward on Start")]
    public float jumpForce = 500f;
    public ParticleSystem particleSystem;
    private int i = 0;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Safety checks
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
            return;
        }

        // Apply an instant upward impulse so the object 'jumps' immediately
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (i < 3)
        {
            i++;
            return;
        }
        else
        {
            Debug.Log("did this play");
            particleSystem.transform.position = transform.position;
            particleSystem.Play();
        }
    }
}