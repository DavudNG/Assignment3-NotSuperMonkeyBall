using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler2D : MonoBehaviour
{
    public PlayerMovement myMovementScript;
    public PlayerAttack myAttackScript;

    private InputAction _movementAction, _jumpAction, _attackAction, _upperAction;

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
        Vector2 movementVector = _movementAction.ReadValue<Vector2>();
        myMovementScript.Move(movementVector);

        if (_jumpAction.triggered)
        {
            myMovementScript.Jump();
        }

        if (_attackAction.triggered)
        {
            myAttackScript.TryAttack();
        }

        if (_upperAction.triggered)
        {
            myAttackScript.TryUppercut();
        }
    }
}
