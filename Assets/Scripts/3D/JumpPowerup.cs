using UnityEngine;

public class JumpPowerup : MonoBehaviour
{
    // What powerup data this powerup uses
    public PowerupData powerupData;

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
        // When the player enters the trigger zone we activate the powerup
        GameObject otherObject = other.gameObject;

        // Play the collection sound
        SoundManager.PlaySound(SoundType.POWERUP);

        // Load the effect handler script
        PlayerEffectHandler effectHandler = other.GetComponent<PlayerEffectHandler>();

        // Check if the other object is the player
        if (otherObject.CompareTag("Player"))
        {
            
            // If we have a valid effect handler and powerup data, apply the effect
            if (effectHandler != null && powerupData != null)
            {
                // Use the data stored in the powerup data scriptable object to apply the effect
                effectHandler.JumpPowerupEffect(powerupData.multiplier, powerupData.duration);
            }

            // Deactivate the powerup object
            this.gameObject.SetActive(false);
        }
    }
}
