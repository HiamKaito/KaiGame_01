using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroStats", menuName = "ScriptableObjects/HeroStats", order = 1)]
public class HeroStats : Stats
{

    public int attack;
    public int speed;
    public int ManaPoint;
    public int defend;
    public int jumpForce;
}
