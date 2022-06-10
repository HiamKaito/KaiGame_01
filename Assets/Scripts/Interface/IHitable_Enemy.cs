using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable_Enemy
{
    void Hit(Hero hero, float damageDeal);
    void HitBy(HeroAssassin heroAssassin, float damageDeal);
}
