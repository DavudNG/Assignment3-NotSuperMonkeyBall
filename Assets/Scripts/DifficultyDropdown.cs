using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private DifficultyData difficultyDataScript;


    public void Start()
    {
        if (PlayerPrefs.GetString("difficulty") == "easy")
        {
            dropdown.value = 0; 
        }
        if (PlayerPrefs.GetString("difficulty") == "medium")
        {
            dropdown.value = 1; 
        }
        if (PlayerPrefs.GetString("difficulty") == "hard")
        {
            dropdown.value = 2; 
        }
    }


    public void SelectHard()
    {
        PlayerPrefs.SetString("difficulty", "hard");
        Debug.Log("changed the difficulty to hard: " + PlayerPrefs.GetString("difficulty"));
    }

    public void SelectMedium()
    {
        PlayerPrefs.SetString("difficulty", "medium");
    }

    public void SelectEasy()
    {
        PlayerPrefs.SetString("difficulty", "easy2");
    }
    public void onValueChanged()
    {
        if (dropdown.value == 0)
        {
            SelectEasy();
        }
        if (dropdown.value == 1)
        {
            SelectMedium();
        }
        if (dropdown.value == 2)
        {
            SelectHard();
        }
    }
}
