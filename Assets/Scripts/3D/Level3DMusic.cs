using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3DMusic : MonoBehaviour
{
    // From James
    IEnumerator levelCoroutine() // Coroutine to ensure only 1 soundtrack plays at a time
    {
        stopPlaying = true; // While this cooldown is active, do not play another soundtrack
        yield return new WaitForSeconds(135f); // No other soundtrack can be played for the duration of the currently playing soundtrack
        stopPlaying = false; // Another soundtrack can be played now
    }

    private bool stopPlaying = false; // Variable to store the cooldown time between sounds
    

    // Update is called once per frame
    void Update()
    {
        if (!stopPlaying) // If no soundtrack is currently playing, play the soundtrack
        {
            SoundManager.PlaySound(SoundType.LEVEL1MUSIC); // Play the soundtrack at 10% volume
            StartCoroutine(levelCoroutine()); // Start the level 1 song cooldown to ensure only 1 instance of the soundtrack plays at a time
        }
    }
}
