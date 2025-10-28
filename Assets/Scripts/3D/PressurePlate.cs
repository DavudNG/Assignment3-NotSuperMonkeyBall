using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    // This is the "bridge" that the script will activate
    public GameObject targetObject;

    // Reference the top part of the pressure plate
    public GameObject topPressurePlate;
    // Will hold the initial position of the top pressure plate
    Vector3 topPlateColliderInit;

    // A force to lower the top pressure plate by - used instead of hardcoding values as it'seasier to test
    public float pressForce = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure the target object is initially deactivated
        targetObject.SetActive(false);

        // Store the initial position of the top part of the pressure plate
        topPlateColliderInit = topPressurePlate.transform.localPosition;
    }

    // When an object collides with the pressure plate
    // We activate the target object
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pressure plate activated");
        // This code exectues when something collides with the pressure plate
        targetObject.SetActive(true);

        // Lower the top part of the pressure plate to simulate being pressed
        topPressurePlate.transform.localPosition = new Vector3(0, pressForce, 0);

        // Play the pressure plate sound
        SoundManager.PlaySound(SoundType.PRESSUREPLATEA);
    }

    // When an object leaves the pressure plate
    // We deactivate the target object
    private void OnTriggerExit(Collider other)
    {
        // This code executes when something leaves the pressure plate
        targetObject.SetActive(false);

        // Reset the top part of the pressure plate to its initial position
        topPressurePlate.transform.localPosition = topPlateColliderInit;

        // Play the pressure plate sound
        SoundManager.PlaySound(SoundType.PRESSUREPLATEB);
    }
}
