using UnityEngine;

public class FinishFlag3D : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // This line gets the other rigidbody component of the object that entered the trigger area
        Rigidbody rb = other.attachedRigidbody;

        // Need to check that the other object actually has a rigid body
        // If the rigid body comes from the Ball then the level is complete
        if (rb != null && other.CompareTag("Ball"))
        {
            // We need to read the players score at the time of collision
            // This is the 'currentTime', or the amount of time left in the level
            // 'currentTime' is essentially the players score
            int score = (int)FindObjectOfType<LevelTimerScript>().currentTime; //deprecated but works for now
            // Find the finish level UI elements
            FinishLevelScript finishLevel = FindObjectOfType<FinishLevelScript>(); //deprecated but works for now

            // Play the sound dictating the end of the level
            // SoundManager.PlaySound(SoundType.WIN);
            
            // Some debugging
            Debug.Log("Level Complete! Score: " + score);
            // Shows the finish level screen, passing thrtough the players score and the current level index
            finishLevel.DisplayFinishLevelScreen(score, UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
