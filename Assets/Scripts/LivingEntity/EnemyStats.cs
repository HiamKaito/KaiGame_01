using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : Stats
{

    public int attack;
    public int speed;
    public int H_AssAtk_Inc;
    public int H_AssAtk_Des;

}
