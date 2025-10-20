using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Custom/DifficultyData")]

public class DifficultyData : ScriptableObject
{
    private float jumpForce = 50;
    private float moveSpeed = 25;

    public float GetJumpForce()
    {
        return jumpForce;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void ChangeJumpForce(float change_value)
    {
        jumpForce = change_value;
    }
    public void ChangeMoveSpeed(float change_value)
    {
        moveSpeed = change_value;
    }
}
