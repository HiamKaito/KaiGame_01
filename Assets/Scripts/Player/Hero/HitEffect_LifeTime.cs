using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect_LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 0.15f;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
