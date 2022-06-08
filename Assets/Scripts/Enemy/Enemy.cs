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

    [SerializeField] protected bool _isAlive = true;
    public bool isAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
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
    // public abstract void hitBy(HeroAssassin hero);
    public abstract void hitBy(HeroAssassin hero, float damage);


    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);

        // create and set Text Damage
        //TODO need optimize : dont destroy it, just set visible and reload position
        var textDamage = Instantiate(_floatingTextDame, new Vector3(transform.position.x, transform.position.y + 2), Quaternion.identity);
        // _floatingTextDame.GetComponent<FloatingText>().setText(damage);
        textDamage.GetComponent<FloatingText>().setText(" " + damage);


        _animController.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage, 0, base._maxHitPoint);
        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);

        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        //*turn off collider reduce lag and modify rigidbody
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        _isAlive = false;

        _animController.Death();

        _heathBarController.Destroy();
        Destroy(gameObject, 3f);
    }
}
