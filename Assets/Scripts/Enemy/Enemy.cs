using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : LivingEntity, IHitable_Enemy
{

    [Header("Enemy Stats")]
    [SerializeField] protected EnemyStats _stats;
    [Space(10)]
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


    [Space(10)]
    [Header("Get Object")]
    [SerializeField] protected E_AnimController _animController;

    [SerializeField] protected GameObject _floatingTextDame;
    [SerializeField] protected GameObject _blood;

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

    public abstract void Hit(Hero hero, float damageDeal);
    public abstract void HitBy(HeroAssassin hero, float damage);
    public abstract void HitBy(HeroWizard heroWizard, float damage);


    public override void takeDamage(float damage)
    {
        // create and set Text Damage
        //TODO need optimize : dont destroy it, just set visible and reload position
        var textDamage = Instantiate(_floatingTextDame, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        //! BUG SHOW ERROR
        textDamage.GetComponent<FloatingText>().setText(" " + damage);


        var blood = Instantiate(_blood, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);


        _animController.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage, 0, base._maxHitPoint);
        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);


        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }

    public override void Destroy()
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
