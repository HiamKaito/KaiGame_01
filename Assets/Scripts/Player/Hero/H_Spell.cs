using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Spell : MonoBehaviour
{
    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private HeroWizard _hero;
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _hero = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroWizard>();

        _rb2D.velocity = transform.right * _speed;

        Destroy(gameObject, 0.3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _hero.dealDamage(other);
    }
}
