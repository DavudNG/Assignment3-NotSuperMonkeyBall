using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyData", menuName = "Custom/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    public float speed;
    public int health;
}
