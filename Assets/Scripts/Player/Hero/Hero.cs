using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : LivingEntity, IHitable_Hero
{
    [Header("Player Stats")]
    [SerializeField] protected HeroStats _stats;

    public HeroStats stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    [Space(10)]
    [Header("Get Object")]
    [SerializeField] protected PlayerController _playerCtrl;
    [SerializeField] protected HeathBarController _hpCtrl;

    [SerializeField] protected GameObject _floatingTextDame;
    [SerializeField] protected GameObject _blood;
    [SerializeField] private GameObject _UIDeath;

    private void Start()
    {
        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;

        _playerCtrl = GetComponent<PlayerController>();
        _hpCtrl = GetComponentInChildren<HeathBarController>();

        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;

        _hpCtrl.SetHealthBar(base._hitPoint, base._maxHitPoint);
    }

    public abstract void HeroAttack();
    public abstract void Hit(Enemy ememy, float damageDeal);
    public abstract void Hit(ObjectCanBreak objectCanBreak, float damageDeal);

    public abstract void HitBy(E_Goblin e_Goblin, float damageDeal);

    public abstract void HitBy(E_Mushroom e_Mushroom, float damageDeal);

    public override void takeDamage(float damage)
    {
        // create and set Text Damage
        //TODO need optimize : dont destroy it, just set visible and reload position
        var textDamage = Instantiate(_floatingTextDame, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        //! BUG SHOW ERROR
        textDamage.GetComponent<FloatingText>().setText(" " + damage);


        var blood = Instantiate(_blood, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);


        _playerCtrl.isDamaged();

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage, 0, base._maxHitPoint);
        _hpCtrl.SetHealthBar(base._hitPoint, base._maxHitPoint);


        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }

    public override void Destroy()
    {
        //*turn off collider reduce lag and modify rigidbody
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        _playerCtrl.Death();

        _hpCtrl.Destroy();

        Instantiate(_UIDeath, new Vector3(0, 0, 0), Quaternion.identity);
        GameManagement.instants.dead();
        Destroy(gameObject, 3f);
    }
}
