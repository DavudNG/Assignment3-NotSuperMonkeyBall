using UnityEngine;

public class Lever : MonoBehaviour

{
    // The radius that the player needs to be in to "interact"
    public float radius = 3f;
    // What key the player needs to press to interact
    public KeyCode interactKey = KeyCode.E;
     // This is the "bridge" that the script will activate
    public GameObject targetObject;
    // A reference to the player - so the script knows when we are in radius
    private Transform player;
    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        targetObject.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly check how far away the player is from the lever
        float distance = Vector3.Distance(player.position, transform.position);

        // Once the player is in the radius, we can check for an input
        if (distance <= radius)
        {
            // When the player presses the interact key
            if (Input.GetKeyDown(interactKey))
            {
                // Handle the interaction
                Interact();
            }
        }
        
        // Once the lever is active, the bridge should always be on
        //  We don't want to continuosly set the bridge to off is the lever is not active
        //  Otherwise, the pressure plate would not work
        if(isActive == true)
        {
            // Set the target object active state based on isActive bool
            targetObject.SetActive(isActive);
        }
    }

    void Interact()
    {
        // Make sure the script is targeting a valid object
        if (targetObject != null)
        {
            // Toggle the target object's active state
            isActive = !isActive;
        }
    }
}
