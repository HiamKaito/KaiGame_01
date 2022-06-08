using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAssassin : Hero
{
    [SerializeField] private Vector2 _point;
    [SerializeField] private float _atkRange;

    public void HeroAttack()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(FixedPoint(), _atkRange);

        if (col != null)
        {
            foreach (Collider2D enity in col)
            {
                if (enity.CompareTag("Enemy"))
                {
                    // enity.GetComponent<LivingEntity>().takeDamage(stats.attack);
                    // Debug.Log("Attack enemy");
                    if (PlayerController.instants.ComboCount == 2)
                    {
                        enity.GetComponent<Enemy>().hitBy(this, base.stats.attack * 2);
                    }
                    else
                    {
                        enity.GetComponent<Enemy>().hitBy(this, base.stats.attack);
                    }
                }
            }
        }
    }

    public Vector2 FixedPoint()
    {
        var vector2 = new Vector2();

        if (PlayerController.instants.isFacingRight)
        {
            vector2.x = _point.x + transform.position.x;
            vector2.y = _point.y + transform.position.y;
        }
        else
        {
            vector2.x = transform.position.x - _point.x;
            vector2.y = transform.position.y - _point.y;
        }

        return vector2;
    }

    void OnDrawGizmosSelected()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(FixedPoint(), _atkRange);
    }
}
