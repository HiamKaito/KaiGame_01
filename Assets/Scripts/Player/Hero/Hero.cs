using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : LivingEntity
{
    [Header("Player Stats")]
    [SerializeField] private HeroStats _stats;

    public HeroStats stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    private void Start()
    {
        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;
    }
    // public  void hitBy(HeroWarrior hero);
}
