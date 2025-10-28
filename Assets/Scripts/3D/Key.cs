using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{

    // This is the "bridge" that the script will activate
    public GameObject targetObject;

    // Keep track of whether the key has been collected
    bool activated = false;

    // Keep track of the bridge's initial height
    float initialHeight = 0f;
    // Keep track of which direction the key is moving - for animation 
    int movingDir = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure the target bridge is disabled when the scene loads
        targetObject.SetActive(false);

        // Get the height that the bridge starts at
        initialHeight = this.gameObject.transform.position.y;
    }
    
    void Update()
    {
        // Once the key is collected, always show the bridge
        if (activated == true)
        {
            targetObject.SetActive(true);
        }

        // Keep track of where the key is
        float currentHeight = this.gameObject.transform.position.y;

        // When the key is 1 unit above its initial height, it should stop moving up
        if (currentHeight >= initialHeight + 0.5f)
        {
            Debug.Log("Reversing to down");
            movingDir = 0;
        }

        // When the key is 1 unit below it's initial height, it should stop moving down
        if (currentHeight <= initialHeight - 0.5f)
        {
            Debug.Log("Reversing direction to up");
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
        // This triggers when the player collides with the key

        // Remove the key from the scene
        // Tried to use SetActive(false), but doesn't seem to work here?
        this.transform.Translate(0f, -100f, 0f);

        // Enable the bridge through this boolean
        activated = true;
    }
}
