using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    [Header("Entity Health Point")]
    [SerializeField] protected float _maxHitPoint;
    [SerializeField] protected float _hitPoint;

    public abstract void takeDamage(float damage); //=> Debug.Log("I got hit : " + damage);
    public abstract void Destroy();

}
