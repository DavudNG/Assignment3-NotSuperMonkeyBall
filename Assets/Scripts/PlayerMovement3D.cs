using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement3D : MonoBehaviour
{
    public CharacterController myCharacterController;
    public Animator myAnimator; // Ref to the Animator of the player
    public PlayerData3D myPlayerData;

    public float currentAttackTimer; // float that represents the current Attack timer
    public float currentJumpTime; // float that represents the current jump timer
    public Vector3 raySize; // size of the ray cast to use
    public float castDistance; // off set of the ray cast to use
    public LayerMask groundLayer; // ref to the groundlayer tag
    public LayerMask interactableLayer; // ref to the interactable layer tag
    public float pushPower = 2.0f; // power to push rigidbodies when colliding with them
    public ParticleSystem landParticles;
    public ParticleSystem attackParticles;
    private bool landPartOnce = false;
    private int attackPartAfter = 0;

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
        
        //if (currentJumpTime > 0)
        //{
        //    currentJumpTime -= Time.deltaTime;
        //}

        if (currentAttackTimer > 0)
        {
            currentAttackTimer -= Time.deltaTime;
        }
    }

    // Apply forces in FixedUpdate
    private void FixedUpdate()
    {
        if (!isGrounded())
        {
            myCharacterController.Move(new Vector3(0, -myPlayerData.gravityForce * myPlayerData.gravityForceMultiplier * Time.deltaTime, 0));
        }
    }

    public void Move(Vector2 movementVector)
    {
        Vector3 v3ToMove = new Vector3 (movementVector.x, 0 , movementVector.y);
        if(v3ToMove != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(v3ToMove);
            //transform.rotation = rotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, myPlayerData.rotationSpeed * Time.deltaTime);
        }
        v3ToMove = v3ToMove * myPlayerData.movementSpeedMultiplier * Time.deltaTime;
        myCharacterController.Move(v3ToMove);
    }

    public void Jump()
    {
        if (currentJumpTime < myPlayerData.maxJumpTime)
        {
            Debug.Log("when does this play");
            landPartOnce = true;
            myCharacterController.Move(new Vector3(0, myPlayerData.jumpForce * myPlayerData.jumpForceMultiplier * Time.deltaTime, 0));
            currentJumpTime += Time.deltaTime;
        }
    }
    IEnumerator attackPartCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 offset = transform.forward * 1.3f + transform.right * 1.1f + Vector3.up * 1.15f;
        attackParticles.transform.position = transform.position + offset;
        attackParticles.transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
        attackParticles.Play();
        attackPartAfter = 0;
    }

    public void Attack()
    {
        if (currentAttackTimer <= 0)
        {
            myAnimator.SetTrigger("isAttacking");
            currentAttackTimer = myPlayerData.attackCooldown;
            StartCoroutine(attackPartCoroutine());
        }
    }


    public void Uppercut()
    {
        if (currentAttackTimer <= 0)
        {
            myAnimator.SetTrigger("isUppercutting");
            currentAttackTimer = myPlayerData.attackCooldown;
        }
    }

    public bool isGrounded()
    {
        //RaycastHit hit;
        // checks whether the raycast returns true if it collides with either the groundlayer or interactable
        if (Physics.Raycast(transform.position, Vector3.down, castDistance, groundLayer) || Physics.Raycast(transform.position, Vector3.down, castDistance, interactableLayer))
        {
            if (landPartOnce == true)
            {
                landParticles.transform.position = transform.position;
                landParticles.Play();
                landPartOnce = false;
            }
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
