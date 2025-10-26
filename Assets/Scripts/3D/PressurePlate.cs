using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    // This is the "bridge" that the script will activate
    public GameObject targetObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure the target object is initially deactivated
        targetObject.SetActive(false);
    }

    // When an object collides with the pressure plate
    // We activate the target object
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pressure plate activated");
        // This code exectues when something collides with the pressure plate
        targetObject.SetActive(true);
    }

    // When an object leaves the pressure plate
    // We deactivate the target object
    private void OnTriggerExit(Collider other)
    {
        // This code executes when something leaves the pressure plate
        targetObject.SetActive(false);
    }
}
