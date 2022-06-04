using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAssassin : Hero
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _atkRange;

    public void HeroAttack()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(_point.position, _atkRange);
        if (col != null)
        {
            foreach (Collider2D enity in col)
            {
                if (enity.tag == "Enemy")
                {
                    enity.GetComponent<LivingEntity>().takeDamage(stats.attack);
                    Debug.Log("Attack enemy");
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_point.position, _atkRange);
    }
}
