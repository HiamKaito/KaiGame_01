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


    [SerializeField] protected E_AnimController _animController;

    [SerializeField] protected GameObject _floatingTextDame;
    private void Start()
    {
        _animController = GetComponent<E_AnimController>();
        _heathBarController = GetComponentInChildren<HeathBarController>();
        // _heathBarController = GameObject.Find("HealthBar").GetComponent<HeathBarController>();
        //  _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();

        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;

        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);
    }
    // public abstract void hitBy(HeroWarrior hero);
    public abstract void hitBy(HeroAssassin hero);
    public abstract void hitBy(HeroAssassin hero, float damage);

    public void Destroy()
    {
        _animController.Death();

        _heathBarController.Destroy();
        Destroy(gameObject, 5f);
    }
}
