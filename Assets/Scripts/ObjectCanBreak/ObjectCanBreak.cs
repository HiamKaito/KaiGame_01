using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCanBreak : LivingEntity, IHitable_Enemy
{
    [Header("Enemy Stats")]
    [SerializeField] protected Stats _stats;
    public Stats stats
    {
        get { return _stats; }
        set { _stats = value; }
    }
    [Space(10)]
    [SerializeField] protected HeathBarController _heathBarController;

    [Space(10)]
    [Header("Get Object")]
    [SerializeField] protected GameObject _floatingTextDame;

    private void Start()
    {
        _heathBarController = GetComponentInChildren<HeathBarController>();

        base._maxHitPoint = _stats.HealthPoint;
        base._hitPoint = _maxHitPoint;

        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);
    }



    //! THIS CANT ATTACK PLAYER, SO WTF IS THIS FOR?
    public virtual void Hit(Hero hero, float damageDeal) => Debug.Log("");
    public abstract void HitBy(HeroAssassin heroAssassin, float damageDeal);

    public override void takeDamage(float damage)
    {
        // create and set Text Damage
        //TODO need optimize : dont destroy it, just set visible and reload position
        var textDamage = Instantiate(_floatingTextDame, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        //! BUG SHOW ERROR
        textDamage.GetComponent<FloatingText>().setText(" " + damage);

        base._hitPoint = Mathf.Clamp(base._hitPoint - damage, 0, base._maxHitPoint);
        _heathBarController.SetHealthBar(base._hitPoint, base._maxHitPoint);


        if (base._hitPoint == 0)
        {
            Destroy();
        }
    }


    public override void Destroy()
    {

    }

}
