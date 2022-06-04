using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : Enemy
{
    // public override void hitBy(HeroWarrior hero)
    // {
    //     throw new System.NotImplementedException();
    // }

    public override void hitBy(HeroAssassin hero)
    {
        Debug.Log("I take damage from HeroAssassin : ");
    }
}
