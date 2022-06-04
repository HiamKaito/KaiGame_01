using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : LivingEntity
{

    [Header("Enemy Stats")]
    [SerializeField] private EnemyStats _stats;


    // public abstract void hitBy(HeroWarrior hero);
    public abstract void hitBy(HeroAssassin hero);
}
