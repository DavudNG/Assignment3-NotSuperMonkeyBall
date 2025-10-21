using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public CharacterController myCharacterController;
    public Animator myAnimator; // Ref to the Animator of the player

    public float movementSpeedMultiplier;
    public float jumpForce;
    public float jumpForceMultiplier;
    public float gravityForce;
    public float gravityForceMultiplier;
    public float rotationSpeed;
    public float minimumJumpTime;
    public float currentJumpTime;

    public Vector3 raySize; // size of the ray cast to use
    public float castDistance; // off set of the ray cast to use
    public LayerMask groundLayer; // ref to the groundlayer tag
    public LayerMask interactableLayer; // ref to the interactable layer tag

    //public bool debugGrounded;
    //public LayerMask debugInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debugGrounded = isGrounded();
        //Debug.DrawRay(transform.position, Vector3.down, Color.black);
       //myAnimator.SetFloat("speed", Mathf.Abs(movementInput.x)); // sets the paramater in animation statemachine for the animation to play move
       //myAnimator.SetFloat("vertical_speed", rb.linearVelocity.y); // sets the paramater in animation statemachine for the animation to play jump
        myAnimator.SetBool("isGrounded", isGrounded()); // sets the paramater in animation statemachine for the animation to return to idle
        
        if(myCharacterController.velocity.x > 0 || myCharacterController.velocity.x < 0 || myCharacterController.velocity.z > 0 || myCharacterController.velocity.z < 0)
        {
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
        
        if (currentJumpTime > 0)
        {
            currentJumpTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Uppercut();
            Debug.Log("Test");
        }
    }

    private void FixedUpdate()
    {
        if (!isGrounded() && currentJumpTime <= 0)
        {
            myCharacterController.Move(new Vector3(0, -gravityForce * gravityForceMultiplier * Time.deltaTime, 0));
        }
    }

    public void Move(Vector2 movementVector)
    {
        Vector3 v3ToMove = new Vector3 (movementVector.x, 0 , movementVector.y);
        if(v3ToMove != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(v3ToMove);
            //transform.rotation = rotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        v3ToMove = v3ToMove * movementSpeedMultiplier * Time.deltaTime;
        myCharacterController.Move(v3ToMove);
    }

    public void Jump()
    {
        if(isGrounded())
        {
            myCharacterController.Move(new Vector3(0, jumpForce * jumpForceMultiplier * Time.deltaTime, 0));
            currentJumpTime = minimumJumpTime;
        }
            
    }

    public void Attack()
    {
        myAnimator.SetTrigger("isAttacking");
    }

    public void Uppercut()
    {
        myAnimator.SetTrigger("isUppercutting");
    }

    public bool isGrounded()
    {
            //RaycastHit hit;
            // checks whether the raycast returns true if it collides with either the groundlayer or interactable
            if (Physics.Raycast(transform.position, Vector3.down, castDistance, groundLayer) || Physics.Raycast(transform.position, Vector3.down, castDistance, interactableLayer))
            {
                //Physics.BoxCast(transform.position, raySize, Vector3.down, out hit, Quaternion.identity, castDistance, groundLayer)
                //debugInteractable = hit.collider.gameObject.layer;
                
                // if true
                return true;
            }

            else
            {
                // if nothing
                return false;
            }
    }

    private void OnDrawGizmos()
    {
        Vector3 distance = Vector3.down * castDistance;
        Gizmos.DrawRay(transform.position, distance);
    }
}
