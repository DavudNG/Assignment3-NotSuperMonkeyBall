using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeData", menuName = "Custom/VolumeData")]

public class VolumeData : ScriptableObject
{
    private float volume = 1;
    public float GetVolume()
    {
        return volume;
    }
    public void ChangeVolume(float change_value)
    {
        volume = change_value;
    }
}
