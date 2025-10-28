using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

/*
    ParentEnemy.cs
    Author: James
    Desc: This script provides majority of the code for the enemies, with enemy movement outlined, but allows the child enemy classes to build on it to differenciate them.
*/

public class ParentEnemy : MonoBehaviour
{
    public enum MovementType { backNForth, followPlayer }; // Declares 2 movement types for the enemies
    [SerializeField] private MovementType movementType; // Allows to select a particular movement type for the enemy this script is attached to
    [SerializeField] private float BNF_time; // Time between movements for the "BackAndForth" movement type
    private bool colliding; // Bool to check if a collision is occurring
    public Transform player; // Transform for the player's position for the "FollowPlayer" movement type
    public float followDistance = 15f; // Distance within which y withe enemll start following the player
    public float launchForce = 10f; // Force applied to the player when colliding with the enemy
    public float kickStrength;
    public float launchStrength;
    public DifficultyData easyDifficulty;
    public DifficultyData mediumDifficulty;
    public DifficultyData hardDifficulty;
    private DifficultyData difficultyData;
    
    public SpriteRenderer myRenderer; // Ref to the renderer of the player
    private Coroutine _hitFlashCorotine; // Ref to the coroutine 
    private Color origColor; // To store the original color of the player
    public float flashTime; // Float that denotes the duration of the flash
    private float speed;
    public int health;
    private bool isAlive = true;
    private float countdown = 3; 



    private Rigidbody2D body; // Enemy's Rigidbody2D to control their movement using vectors

    void Start()
    {
        origColor = myRenderer.color; // grab the original colour from the renderer
        body = GetComponent<Rigidbody2D>(); // Gets the Rigidbody2D of the object this script is attached to

        if (movementType == MovementType.backNForth) // If the movement type selected is back and forth
        {
            StartCoroutine(BackAndForth()); // Start the associated back and forth coroutine, which the enemy will forever do
        }
        else if (movementType == MovementType.followPlayer) // If the movement type is follow player
        {
            StartCoroutine(FollowPlayer()); // Start the associated follow player coroutine, which the enemy will forever do
        }

        if (PlayerPrefs.GetString("difficulty") == "easy")
        {
            difficultyData = easyDifficulty;
        }
        if (PlayerPrefs.GetString("difficulty") == "medium")
        {
            difficultyData = mediumDifficulty;
        }
        if (PlayerPrefs.GetString("difficulty") == "hard")
        {
            difficultyData = hardDifficulty;
        }

        speed = difficultyData.speed;
        health = difficultyData.health;
    }

    private void Update()
    {
        if(!isAlive)
        {
            countdown-= Time.deltaTime;
        }
        if(countdown < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    /*
    
    OnCollisionEnter2D
    Author: Angus
    Desc: This function is used to prevent the player from being able to stand on the enemies
            Essentially.. When the player or ball make contact within the enemies trigger zone, the player or ball will be launched up

    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is the object that touched the spring
        GameObject otherObject = collision.gameObject;

        // Apply a force if it has a Rigidbody2D and not already jumping
        Rigidbody2D rb = otherObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply an upwards force
            rb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
            if(rb.gameObject.tag == "Player")
            {
                rb.GetComponent<PlayerHealth>().takeDamage();
            }
        }
    }

    public void TakeDamage(bool flipped)
    {
        if (health > 0)
        {
            health--;
            CallHitFlash(); // call hitflash coroutine
            if(flipped)
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-kickStrength, launchStrength), ForceMode2D.Force);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(kickStrength, launchStrength), ForceMode2D.Force);
            }
        }

        if (health == 0)
        {
            isAlive = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            myRenderer.color = new Color(133, 110, 110); // lerp the colour value from the intended colour back to the original color  
        }

    }
    
    private IEnumerator FollowPlayer() // IEnumerator for the follow player coroutine
    {
        while (isAlive)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > followDistance)
            {
                // Too far away – stop moving
                body.linearVelocity = new Vector2(0, body.linearVelocity.y);
            }
            else
            {
                // Within follow range – move toward player
                Vector2 direction = (player.position - transform.position).normalized; // Get direction
                body.linearVelocity = new Vector2(direction.x * speed, body.linearVelocity.y);
            }

            yield return new WaitForSeconds(0.1f); // Small delay to avoid over-updating
        }
    }
    public void CallHitFlash() 
    {
        _hitFlashCorotine = StartCoroutine(HitFlasher()); // starts the coroutine and sets the reference to it
    }

    /*
        HitFlasher() 
        Author: David
        Desc: IEnumerator that lerps(linear interpolation: smooth transition between 2 points) 
        the renderer's colour values for a duration of time equal to flashtime
    */
    private IEnumerator HitFlasher()
    {
        float elapsedTime = 0f; // float to hold the current elapsed time

        while (elapsedTime < flashTime) // while the elapsed time doesnt exceed the flashtime
        {
            elapsedTime += Time.deltaTime; // increment the elapsed time

            Color lerpedColor = Color.Lerp(Color.red, origColor, elapsedTime / flashTime); // lerp the colour value from the intended colour back to the original color  
            myRenderer.color = lerpedColor; // set the renderer's color each time to transition the color for the hit effect 
            yield return null; // pause the coroutine for a single frame 
        }
    }


    private IEnumerator BackAndForth() // IEnumerator for the back and forth coroutine
    {
        while (isAlive) // Infinite loop
        {
            body.linearVelocity = new Vector2(-speed, body.linearVelocity.y); // Move to the left
            yield return new WaitForSeconds(BNF_time); // Wait for the selected time
            body.linearVelocity = new Vector2(speed, body.linearVelocity.y); // Move to the right
            yield return new WaitForSeconds(BNF_time); // Wait for the selected
        }
    }
}
