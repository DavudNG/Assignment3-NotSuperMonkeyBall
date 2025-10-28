using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private DifficultyData difficultyDataScript;

    public void Start()
    {
        if (difficultyDataScript.GetMoveSpeed() == 35)
        {
            dropdown.value = 0;
        }
        if (difficultyDataScript.GetMoveSpeed() == 25)
        {
            dropdown.value = 1;
        }
        if (difficultyDataScript.GetMoveSpeed() == 12)
        {
            dropdown.value = 2;
        }
    }


    public void SelectHard()
    {
        difficultyDataScript.ChangeJumpForce(5);
        difficultyDataScript.ChangeMoveSpeed(12);
        PlayerPrefs.SetString("difficulty", "hard");
        Debug.Log("changed the difficulty to hard: " + PlayerPrefs.GetString("difficulty"));
    }

    public void SelectMedium()
    {
        difficultyDataScript.ChangeJumpForce(10);
        difficultyDataScript.ChangeMoveSpeed(25);
        PlayerPrefs.SetString("difficulty", "medium");
    }

    public void SelectEasy()
    {
        difficultyDataScript.ChangeJumpForce(20);
        difficultyDataScript.ChangeMoveSpeed(35);
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
