using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Mushroom : Enemy
{
    public override void hitBy(HeroAssassin hero, float damage)
    {
        damage /= 2;
        base.takeDamage(damage);
    }
}