using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    //creates array for level buttons.
    public Button[] lvlButtons;
    //creates array for high score text
    public TextMeshProUGUI[] scoreTexts;
    [SerializeField] private DifficultyData difficultyDataScript;

    void Start()
    {
        if (difficultyDataScript.GetJumpForce() == 50)
        {
            Debug.Log("screwed up");
        }
        else
        {
            Debug.Log("passed the vibe check");
        }
        //obtains Player pref for "lvlAt". If null, sets it to 2.
        int lvlAt = PlayerPrefs.GetInt("lvlAt", 2);

        //code to lock levels the player cannot access.
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            int levelIndex = i + 2;

            if (levelIndex > lvlAt)
            {
                Debug.Log(levelIndex);
                Debug.Log(lvlAt);
                lvlButtons[i].interactable = false;
            }

            //sets level high score based on player pref key
            string key = "HighScore_Level" + levelIndex;
            int highScore = PlayerPrefs.GetInt(key, 0);

            if (scoreTexts.Length > i && scoreTexts[i] != null)
            {
                scoreTexts[i].text = $"High Score: {highScore}";
            }
        }
    }
}
