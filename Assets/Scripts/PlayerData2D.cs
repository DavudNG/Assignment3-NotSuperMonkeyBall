using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData2D", menuName = "Scriptable Objects/PlayerData2D")]
public class PlayerData2D : ScriptableObject
{
    public int health; // int the value that denotes how much health the player has left
    public float moveSpeed; // float movement speed of the player
    public float jumpForce; // float jump strength of the player
}
