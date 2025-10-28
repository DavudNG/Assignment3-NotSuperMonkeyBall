using UnityEngine;

// Powerup data scriptable object to hold all parameters for a powerup

[CreateAssetMenu(fileName = "NewPowerup", menuName = "Powerups/Powerup Data")]
public class PowerupData : ScriptableObject
{
    // All of the parameters for a powerup
    public string powerupName;
    public float multiplier;
    public float duration;
    public PowerupType type;
}

public enum PowerupType
{
    // All the current powerups we have
    Jump
}