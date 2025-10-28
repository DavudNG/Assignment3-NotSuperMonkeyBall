using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    int levelProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        levelProgress = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (levelProgress > 2)
        {
            int score = (int)FindObjectOfType<LevelTimerScript>().currentTime; //deprecated but works for now
            // Find the finish level UI elements
            FinishLevelScript finishLevel = FindObjectOfType<FinishLevelScript>(); //deprecated but works for now
            // Play the sound dictating the end of the level
            SoundManager.PlaySound(SoundType.WIN);
            // Some debugging
            Debug.Log("Level Complete! Score: " + score);
            // Shows the finish level screen, passing thrtough the players score and the current level index
            finishLevel.DisplayFinishLevelScreen(score, UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void IncreaseProgress()
    {
        levelProgress+= 1;
    }
}
