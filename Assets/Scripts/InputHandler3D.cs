using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler3D : MonoBehaviour
{
    public PlayerMovement3D myMovementScript;

    private InputAction _movementAction , _jumpAction, _attackAction, _upperAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _attackAction = InputSystem.actions.FindAction("Attack");
        _upperAction = InputSystem.actions.FindAction("Uppercut");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _movementAction.ReadValue<Vector2>(); // read the axis of movement
        myMovementScript.Move(movementVector); // send the data

        if (_jumpAction.IsPressed()) // when jump action is pressed
        {
            myMovementScript.Jump(); // call the jump function
        }

        if (_attackAction.triggered) // when attack action is pressed
        {
            myMovementScript.Attack(); // call the jump function
        }

        if (_upperAction.triggered) // when uppercut action is pressed
        {
            myMovementScript.Uppercut(); // call the jump function
        }
    }

    //quick functions to disable inputs
    public void DisableAllInputs()
    {
        _movementAction.Disable();
        _jumpAction.Disable();
        _attackAction.Disable();
        _upperAction.Disable();
    }
    //quick functions to enable inputs
    public void EnableAllInputs()
    {
        _movementAction.Enable();
        _jumpAction.Enable();
        _attackAction.Enable();
        _upperAction.Enable();
    }
}
