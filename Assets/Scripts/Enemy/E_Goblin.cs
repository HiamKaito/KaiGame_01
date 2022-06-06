using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Goblin : Enemy
{
    public override void hitBy(HeroAssassin hero)
    {
        E_AnimController.instants.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - hero.stats.attack * 1.5f, 0, _maxHitPoint);
        base._heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }

    public override void hitBy(HeroAssassin hero, float damage)
    {
        E_AnimController.instants.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage * 1.5f, 0, _maxHitPoint);
        base._heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }
}