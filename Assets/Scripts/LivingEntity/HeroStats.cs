using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroStats", menuName = "ScriptableObjects/HeroStats", order = 1)]
public class HeroStats : ScriptableObject
{
    public int HealthPoint;
    public int ManaPoint;
    public int defend;
    public int attack;
    public int speed;
    public int jumpForce;
}
