using UnityEngine;

public class BallHealth3D : MonoBehaviour
{
    public int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //// Handle logic when the ball falls off the platform
       //if(this.transform.position.y < 45)
       //{
       //    // Remove 100 health killing the ball
       //    registerHit(100);
       //}
    }

    // Use a function inside the ball to register a hit
    // This can be used outside of this script providing basically a "setter" for the balls health
    // Use a default value of 1, however this can be overridden
    public void registerHit(int damage)
    {
        // Subtract one from health
        health -= damage;
        // This triggers when the ball dies
        if (health <= 0)
        {
            DeathMenuScript deathMenu = FindObjectOfType<DeathMenuScript>();
            deathMenu.DisplayDeathScreen();
        }
    }
}
