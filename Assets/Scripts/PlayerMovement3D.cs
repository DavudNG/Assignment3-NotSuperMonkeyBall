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
    public float pushPower = 2.0f; // power to push rigidbodies when colliding with them

    [Tooltip("Impulse strength applied upward on Start")]
    public float jumpForce = 500f;
    public ParticleSystem particleSystem;
    private int i = 0;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // Safety checks
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on " + gameObject.name);
            return;
        }

        // Apply an instant upward impulse so the object 'jumps' immediately
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (i < 3)
        {
            i++;
            return;
        }
        else
        {
            Debug.Log("did this play");
            particleSystem.transform.position = transform.position;
            particleSystem.Play();
        }
}

  void Update(){
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
    
    // From AI
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody, no push
        if (body == null || body.isKinematic)
            return;

        // We don't want to push things below us (like the floor)
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate the push direction (horizontal only)
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply the push force to the rigidbody
        body.AddForce(pushDir * pushPower, ForceMode.VelocityChange);
    }

    //debug raycast draw gizmo
    private void OnDrawGizmos()
    {
        Vector3 distance = Vector3.down * castDistance;
        Gizmos.DrawRay(transform.position, distance);
    }
}