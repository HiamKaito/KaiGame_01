using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : Enemy
{
    public override void hitBy(HeroWarrior hero)
    {
        takeDamage();
    }

    public override void hitBy(HeroAssasin hero)
    {
        throw new System.NotImplementedException();
    }
}
