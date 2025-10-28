using UnityEngine;

public class JumpPowerup : MonoBehaviour
{
    // Keep track of whether the key has been collected
    bool activated = false;

    // Keep track of the bridge's initial height
    float initialHeight = 0f;
    // Keep track of which direction the key is moving - for animation 
    int movingDir = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the height that the powerup starts at
        initialHeight = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep track of where the key is
        float currentHeight = this.gameObject.transform.position.y;

        // When the powerup is 1 unit above its initial height, it should stop moving up
        if (currentHeight >= initialHeight + 0.5f)
        {
            movingDir = 0;
        }

        // When the powerup is 1 unit below it's initial height, it should stop moving down
        if (currentHeight <= initialHeight - 0.5f)
        {
            movingDir = 1;
        }

        // Based on the moving direction, move the bridge up or down
        if (movingDir == 1)
        {
            // Move the key up
            this.gameObject.transform.Translate(0f, 0.005f, 0f);
        }
        else
        {
            // Move the key down
            this.gameObject.transform.Translate(0f, -0.005f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger zone we make it jump
        GameObject otherObject = other.gameObject;

        // Load the effect handler script
        PlayerEffectHandler effectHandler = other.GetComponent<PlayerEffectHandler>();

        // Check if the other object is the player
        if (otherObject.CompareTag("Player"))
        {
            Debug.Log("Player collected jump powerup!");
            // Activate the powerup effect
            effectHandler.JumpPowerupEffect(4.0f, 5.0f);

            // Dissapear the game object to set the appearance of being collected
            this.gameObject.SetActive(false);
        }
    }
}
