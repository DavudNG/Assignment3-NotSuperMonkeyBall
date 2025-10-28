using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    [SerializeField] private DifficultyData difficultyDataScript;

    void Start()
    {

    }

    //each method is used in a button to load its specific scene number.
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void changeGlobalFonts()
    {
        // Reload the TMP assets in the scene by looking  through all FontSwitch scripts
        foreach (var text in FindObjectsOfType<FontSwitch>())
        {
            // Use the ApplyFont method to update the font based on the new setting
            text.ApplyFont();
        }
    }
}
