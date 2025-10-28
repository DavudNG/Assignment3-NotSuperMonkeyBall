using System.Collections;
using UnityEngine;

public class Spring3D : MonoBehaviour
{
    private bool isJumping = false;

    // Public variables determining jump force - easier to edit
    public float jumpForce = 20f;

    Vector3 Direction = Vector3.forward;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger zone we make it jump
        GameObject otherObject = other.gameObject;
        // Get the Rigidbody component of the other object
        Rigidbody rb = otherObject.GetComponent<Rigidbody>();
        // Make the object jump if it has a Rigidbody and is not already jumping
        if (rb != null && !isJumping)
        {
            // Start the jump coroutine
            StartCoroutine(jump(rb));
        }

        // Play the key collection sound
        SoundManager.PlaySound(SoundType.POWERUP);
    }

    IEnumerator jump(Rigidbody rb)
    {
        // Make the object jump
        isJumping = true;
        // Add an 'upward' and 'forward' force to the Rigidbody
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        rb.AddForce(Direction * (jumpForce / 4), ForceMode.Impulse);
        // Wait for a short duration before allowing another jump
        yield return new WaitForSeconds(0.01f);
        // Allow the object to jump again
        isJumping = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        // When the player leaves the trigger zone we can stop jumping
        isJumping = false;
    }
}
