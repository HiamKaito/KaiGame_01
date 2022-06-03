using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : LivingEntity
{
    public abstract void hitBy(HeroWarrior hero);
    public abstract void hitBy(HeroAssasin hero);
}
