using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private DifficultyData difficultyDataScript;

    public void SelectHard()
    {
        difficultyDataScript.ChangeJumpForce(5);
        difficultyDataScript.ChangeMoveSpeed(12);
    }

    public void SelectMedium()
    {
        difficultyDataScript.ChangeJumpForce(10);
        difficultyDataScript.ChangeMoveSpeed(25);
    }

    public void SelectEasy()
    {
        difficultyDataScript.ChangeJumpForce(20);
        difficultyDataScript.ChangeMoveSpeed(35);
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
