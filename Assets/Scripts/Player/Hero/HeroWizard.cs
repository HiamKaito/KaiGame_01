using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWizard : Hero
{
    [SerializeField] private Transform atkSpellPoint;
    [SerializeField] private GameObject spellAtk;

    public override void HeroAttack()
    {
        Instantiate(spellAtk, atkSpellPoint.position, atkSpellPoint.rotation);//.transform.parent = gameObject.transform;
    }

    public void dealDamage(Collider2D enity)
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

}
