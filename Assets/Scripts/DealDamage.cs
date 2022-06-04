using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public void damaged()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 4.0f);
        if (col != null)
        {
            foreach (Collider2D enity in col)
            {
                if (enity.tag == "Enemy")
                    enity.GetComponent<LivingEntity>().takeDamage();
            }
        }
    }


    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("On Trigger Enter");
    //     // if (other.gameObject.layer == LayerMask.NameToLayer("LivingEntity"))
    //     // {
    //     //     var entity = other.GetComponent<LivingEntity>();

    //     //     entity.takeDamage();
    //     // }
    // }

}
