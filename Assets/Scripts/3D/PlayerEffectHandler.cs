using UnityEngine;

public class PlayerEffectHandler : MonoBehaviour
{
    // Reference the player
    public GameObject Player;

    float initialJumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = this.gameObject;
        
        // This is to store the player's initial jump force
        initialJumpForce = Player.GetComponent<PlayerMovement3D>().jumpForce;
    }

    public void JumpPowerupEffect(float multiplier, float duration)
    {
        Debug.Log("Activating jump powerup effect");
        // Increase the player's jump force
        Player.GetComponent<PlayerMovement3D>().jumpForce = initialJumpForce * multiplier;

        // After the duration, reset the jump force
        Invoke("ResetJumpForce", duration);
    }
}
