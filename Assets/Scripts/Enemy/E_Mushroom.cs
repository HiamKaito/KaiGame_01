using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Mushroom : Enemy
{
    public override void hitBy(HeroAssassin hero)
    {
        Instantiate(base._floatingTextDame, new Vector3(transform.position.x, transform.position.y + 2), Quaternion.identity);

        _animController.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - hero.stats.attack, 0, _maxHitPoint);
        base._heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }

    public override void hitBy(HeroAssassin hero, float damage)
    {
        Instantiate(base._floatingTextDame, new Vector3(transform.position.x, transform.position.y + 2), Quaternion.identity);

        _animController.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage, 0, _maxHitPoint);
        base._heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }
}