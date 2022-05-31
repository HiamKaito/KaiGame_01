using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    [Header("Enity stats")]
    public Stats stats;

    [Space(10)]

    [Header("Entity Health Point")]
    [SerializeField] protected float _maxHitPoint;
    [SerializeField] protected float _hitPoint;



}
