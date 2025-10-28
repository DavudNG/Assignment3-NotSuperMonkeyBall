using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnemy : ParentEnemy
{

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("yo");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("yo");
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.Explode(-collision.rigidbody.linearVelocity.normalized * 30, 1.5f);
                playerHealth.takeDamage();
            }
        }
    }
}
