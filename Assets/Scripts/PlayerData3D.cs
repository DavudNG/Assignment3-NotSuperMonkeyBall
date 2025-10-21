using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData3D : ScriptableObject
{
    public float movementSpeedMultiplier;
    public float jumpForce;
    public float jumpForceMultiplier;
    public float gravityForce;
    public float gravityForceMultiplier;
    public float rotationSpeed;
    public float maxJumpTime;
    public float attackCooldown;
}
