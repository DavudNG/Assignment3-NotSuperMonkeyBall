using System.Runtime.CompilerServices;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) // quick function to check the tag and call damage on the player and ball
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth3D>().registerHit(5); // call object to take lethal damage
            Debug.Log("did this play");
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<BallHealth3D>().registerHit(5); // call object to take lethal damage
        }
    }
}
