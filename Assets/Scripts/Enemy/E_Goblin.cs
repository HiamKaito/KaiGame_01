using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Goblin : Enemy
{
    public override void hitBy(HeroAssassin hero, float damage)
    {
        // damage += damage / 2;
        base.takeDamage(damage);
    }
}