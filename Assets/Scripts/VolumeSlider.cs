using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private VolumeData volumeDataScript;

    public void WriteToScriptable()
    {
        volumeDataScript.ChangeVolume(slider.value);
    }
    void Start()
    {
        slider.value = volumeDataScript.GetVolume();
    }
}
