using UnityEngine;

//author: David(Reused Angus's Player Health script)
public class PlayerHealth3D : MonoBehaviour
{

    public int health = 3;
    //public int damage = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Use a function inside the player to register a hit
    // This can be used outside of this script providing basically a "setter" for the players health
    // Use a default value of 1, however this can be overridden
    public void registerHit(int damage)
    {
        // Subtract one from health
        health -= damage;
        // This triggers when the player dies
        if (health <= 0)
        {
            DeathMenuScript deathMenu = FindObjectOfType<DeathMenuScript>();
            deathMenu.DisplayDeathScreen();
        }
    }
}
