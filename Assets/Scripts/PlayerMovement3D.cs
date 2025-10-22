using UnityEngine;
/*
    PlayerAttack.cs     
    Author: David
    Desc: This script handles the players movement and model animations
*/
public class PlayerMovement3D : MonoBehaviour
{
    public CharacterController myCharacterController;
    public Animator myAnimator; // Ref to the Animator of the player
    public PlayerData3D myPlayerData; // ref to the relevant playerdata

    public float currentAttackTimer; // float that represents the current Attack timer
    public float currentJumpTime; // float that represents the current jump timer
    public Vector3 raySize; // size of the ray cast to use
    public float castDistance; // off set of the ray cast to use
    public LayerMask groundLayer; // ref to the groundlayer tag
    public LayerMask interactableLayer; // ref to the interactable layer tag

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // sets the grounded paramater in animation statemachine for the animation to play jump and land related anim
        myAnimator.SetBool("isGrounded", isGrounded());
        
        // check for movement on the x and z axises
        if(myCharacterController.velocity.x > 0 || myCharacterController.velocity.x < 0 || myCharacterController.velocity.z > 0 || 
            myCharacterController.velocity.z < 0)
        {
            myAnimator.SetBool("isMoving", true); // if theres movement set the animator parameter
        }
        else
        {
            myAnimator.SetBool("isMoving", false);// if theres movement reset the animator parameter
        }

        /* 
          if (currentJumpTime > 0)
          {
            currentJumpTime -= Time.deltaTime;
          }
        */

        if (currentAttackTimer > 0) // if attack timer is higher than zero
        {
            currentAttackTimer -= Time.deltaTime; // then decrement it
        }
    }

    // Apply forces in FixedUpdate
    private void FixedUpdate()
    {
        if (!isGrounded()) // when not grounded
        {
            // apply gravity force
            myCharacterController.Move(new Vector3(0, -myPlayerData.gravityForce * myPlayerData.gravityForceMultiplier * Time.deltaTime, 0));
        }
    }

    /*
        Move(Vector2 movementVector)   
        Author: David
        Desc: function thats takes in a vector2 to read the magnitude of movement, rotates the player model to the movement direction
            and applies any multipliers before sending the final vector to the character controller. 
    */
    public void Move(Vector2 movementVector)
    {
        Vector3 v3ToMove = new Vector3 (movementVector.x, 0 , movementVector.y); // store the vector parameters in a local variable
        if(v3ToMove != Vector3.zero) // if the movement isnt zero
        {
            Quaternion rotation = Quaternion.LookRotation(v3ToMove); // calculate the quaternion of the movement vector
                
            // Apply the calculated rotation to the player's model over a duration
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, myPlayerData.rotationSpeed * Time.deltaTime);
        }
        v3ToMove = v3ToMove * myPlayerData.movementSpeedMultiplier * Time.deltaTime; // calculate the final movement vector
        myCharacterController.Move(v3ToMove); // apply the final vector to chara controller
    }

    /*
        Jump()   
        Author: David
        Desc: function checks if the current jump timer is not exceeding the max jump time and applies upward force 
            to the player if it passes the check.
    */
    public void Jump()
    {
        if(currentJumpTime < myPlayerData.maxJumpTime) // if current jump time doesnt exceed max 
        {
            // Calculate and apply upward force to the char controller
            myCharacterController.Move(new Vector3(0, myPlayerData.jumpForce * myPlayerData.jumpForceMultiplier * Time.deltaTime, 0));
            currentJumpTime += Time.deltaTime; // 
        }
    }

    // TODO
    
    /*
        Attack()   
        Author: David
        Desc: 
    */
    public void Attack()
    {
        if (currentAttackTimer <= 0)
        {
            myAnimator.SetTrigger("isAttacking");
            currentAttackTimer = myPlayerData.attackCooldown;
        }
    }


    // TODO

    /*
        Uppercut()   
        Author: David
        Desc: 
    */
    public void Uppercut()
    {
        if (currentAttackTimer <= 0)
        {
            myAnimator.SetTrigger("isUppercutting");
            currentAttackTimer = myPlayerData.attackCooldown;
        }
    }

    /*
        isGrounded()   
        Author: David
        Desc: Checks whether the player is grounded by raycasting down, if it returns a colliding object with the ground 
                or interactable layer 
    */
    public bool isGrounded()
    {
            //RaycastHit hit;
            // checks whether the raycast returns true if it collides with either the groundlayer or interactable
            if (Physics.Raycast(transform.position, Vector3.down, castDistance, groundLayer) || 
                    Physics.Raycast(transform.position, Vector3.down, castDistance, interactableLayer))
            {
            // if true
                currentJumpTime = 0; // reset current jump timer
                return true;
            }

            else
            {
                // if nothing
                return false;
            }
    }

    //debug raycast draw gizmo
    private void OnDrawGizmos()
    {
        Vector3 distance = Vector3.down * castDistance;
        Gizmos.DrawRay(transform.position, distance);
    }
}
