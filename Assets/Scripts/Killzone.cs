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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth3D>().registerHit(5); // call object to take lethal damage
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<BallHealth3D>().registerHit(5); // call object to take lethal damage
        }
    }
}
