using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [CreateAssetMenu(menuName = "Item", fileName = "New Item")]
[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject
{
    public string Name;
    public int HealthPoint;
}