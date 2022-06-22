using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAssassin : Hero
{
    [SerializeField] private Vector2 _point;
    [SerializeField] private float _atkRange;

    public override void HeroAttack()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(FixedPoint(), _atkRange);

        if (col != null)
        {
            foreach (Collider2D enity in col)
            {
                dealDamage(enity);
            }
        }
    }

    private void dealDamage(Collider2D enity)
    {
        float damageDeal = base.stats.attack;
        switch (PlayerController.instants.ComboCount)
        {
            case 1: damageDeal *= 1f; break;
            case 2: damageDeal *= 2; break;
        }

        if (enity.CompareTag("Enemy")) { Hit(enity.GetComponent<Enemy>(), damageDeal); }
        if (enity.CompareTag("ObjectCanBreak")) { Hit(enity.GetComponent<ObjectCanBreak>(), damageDeal); }
    }

    public override void Hit(Enemy enemy, float damageDeal)
    {
        // Debug.Log("hero assasin hasagi monster");
        Debug.Log(base._stats.Name + " deal damage " + damageDeal + " to " + enemy.stats.Name);
        enemy.HitBy(this, damageDeal);
    }

    public override void Hit(ObjectCanBreak objectCanBreak, float damageDeal)
    {
        Debug.Log(base._stats.Name + " deal damage " + damageDeal + " to " + objectCanBreak.stats.Name);
        objectCanBreak.HitBy(this, damageDeal);
    }

    public override void HitBy(E_Goblin e_Goblin, float damageDeal)
    {
        Debug.Log(base._stats.Name + " take damage " + damageDeal + " from " + e_Goblin.stats.Name);
        base.takeDamage(damageDeal);
    }

    public override void HitBy(E_Mushroom e_Mushroom, float damageDeal)
    {
        damageDeal += e_Mushroom.stats.H_AssAtk_Inc;
        Debug.Log(base._stats.Name + " take damage " + damageDeal + " from " + e_Mushroom.stats.Name);
        base.takeDamage(damageDeal);
    }

    public Vector2 FixedPoint()
    {
        var vector2 = new Vector2();

        if (PlayerController.instants.isFacingRight)
        {
            vector2.x = transform.position.x + _point.x;
            vector2.y = transform.position.y + _point.y;
        }
        else
        {
            vector2.x = transform.position.x - _point.x;
            vector2.y = transform.position.y - _point.y;
        }

        return vector2;
    }


    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawWireSphere(FixedPoint(), _atkRange);
    // }
}
