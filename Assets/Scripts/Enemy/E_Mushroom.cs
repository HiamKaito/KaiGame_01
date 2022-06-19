using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Mushroom : Enemy
{
    public override void Hit(Hero hero, float damageDeal)
    {
        Debug.Log(base._stats.Name + " deal damage " + damageDeal + " to " + hero.stats.Name);
        hero.HitBy(this, damageDeal);
    }

    public override void HitBy(HeroAssassin hero, float damage)
    {
        damage -= base._stats.H_AssAtk_Des;

        Debug.Log(base._stats.Name + " got damaged " + damage + " by " + hero.stats.Name);

        base.takeDamage(damage);
    }

    public override void HitBy(HeroWizard hero, float damage)
    {
        Debug.Log(base._stats.Name + " got damaged " + damage + " by " + hero.stats.Name);

        base.takeDamage(damage);
    }
}