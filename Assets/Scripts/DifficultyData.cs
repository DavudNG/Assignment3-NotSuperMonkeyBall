using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Custom/DifficultyData")]

public class DifficultyData : ScriptableObject
{
    private float jumpForce = 20;
    private float moveSpeed = 35;

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

    public void sceneChangeCheck()
    {
        if ((PlayerPrefs.GetString("difficulty") == "easy2") && (moveSpeed != 35))
        {
            moveSpeed = 35;
            jumpForce = 20;
            Debug.Log("playerprefs reset to easy");
        }
        if ((PlayerPrefs.GetString("difficulty") == "medium") && (moveSpeed != 25))
        {
            moveSpeed = 35;
            jumpForce = 20;
            Debug.Log("playerprefs reset to medium");
        }
        if ((PlayerPrefs.GetString("difficulty") == "hard") && (moveSpeed != 12))
        {
            moveSpeed = 35;
            jumpForce = 20;
            Debug.Log("playerprefs reset to hard");
        }
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetString("difficulty", "easy2");
            Debug.Log("playerprefs setstring to easy");
        }
    }
}
