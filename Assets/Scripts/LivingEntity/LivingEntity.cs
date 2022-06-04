using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour, IHitable
{
    [Header("Entity Health Point")]
    [SerializeField] protected float _maxHitPoint;
    [SerializeField] protected float _hitPoint;

    public virtual void takeDamage() => Debug.Log("I got hit");

    public virtual void takeDamage(int damage) => Debug.Log("I got hit : " + damage);

}
