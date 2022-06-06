using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : LivingEntity
{

    [Header("Enemy Stats")]
    [SerializeField] protected EnemyStats _stats;
    [SerializeField] protected HeathBarController _heathBarController;

    public EnemyStats stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    private void Start()
    {
        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;

        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);
    }
    // public abstract void hitBy(HeroWarrior hero);
    public abstract void hitBy(HeroAssassin hero);
    public abstract void hitBy(HeroAssassin hero, float damage);

    public void Destroy()
    {
        E_AnimController.instants.Death();

        Destroy(_heathBarController);
        Destroy(gameObject, 3f);
    }
}
