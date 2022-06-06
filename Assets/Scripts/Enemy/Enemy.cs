using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : LivingEntity
{

    [Header("Enemy Stats")]
    [SerializeField] private EnemyStats _stats;
    public EnemyStats stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    private void Start()
    {
        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;
    }
    // public abstract void hitBy(HeroWarrior hero);
    public abstract void hitBy(HeroAssassin hero);
}
