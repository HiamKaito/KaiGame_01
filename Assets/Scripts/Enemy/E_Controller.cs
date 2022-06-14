using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Controller : MonoBehaviour
{
    [Header("Enemy Controller")]
    [SerializeField] private Transform playerPosition;
    public float x, y;

    [Space(10)]
    [Header("Get Object")]
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private E_AnimController _animController;
    [SerializeField] private E_PlayerSensor _playerSensor;

    [Space(10)]
    [Header("Attack Point")]
    [SerializeField] private Vector2 _point;
    [SerializeField] private float _atkRange = 3.0f;
    [SerializeField] private int _currentCombo = 0;
    [SerializeField] private float _atkDelay = 0.0f;
    [SerializeField] private float _atkTimeDelay = 1.5f;
    [SerializeField] private int _atkCount = 0;
    [SerializeField] private int[] _listCombo;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        _rb2D = FindObjectOfType<Rigidbody2D>();

        //TODO need better part 2
        _enemy = GetComponent<E_Goblin>();
        if (_enemy == null)
        {
            // find another class
            _enemy = GetComponent<E_Mushroom>();
        }

        _animController = GetComponent<E_AnimController>();
        _playerSensor = GetComponentInChildren<E_PlayerSensor>();
    }

    private void FixedUpdate()
    {
        //* if enemy death
        if (!_enemy.isAlive)
        {
            GetComponent<E_Controller>().enabled = false;
            return;
        }

        if (playerPosition == null) return;

        if (isInAttackRange() && Time.time > _atkDelay)
        {
            _animController.checkMove(0);
            //* =================================

            _animController.attackAtCombo(_listCombo[_atkCount]);
            _currentCombo = _listCombo[_atkCount];
            _atkCount++;

            if (_atkCount >= _listCombo.Length)
            {
                _atkCount = 0;
            }
            // if (_atkCount < 3)
            // {
            //     _animController.attackAtCombo(1);
            //     _currentCombo = 1;
            //     _atkCount++;
            // }
            // else
            // {
            //     _animController.attackAtCombo(2);
            //     _currentCombo = 2;
            //     _atkCount = 0;
            // }
            //* =================================

            _atkDelay = Time.time + _atkTimeDelay;
        }
        else
        {
            moveToTarget();
        }
    }

    public void Movement(float x, float y)
    {
        Vector2 vt2 = new Vector2();

        if (_animController.isFacingRight) { vt2 = new Vector2(x + _atkRange - 1.0f, y); }
        else { vt2 = new Vector2(x - _atkRange + 1.0f, y); }

        transform.position = Vector2.MoveTowards(
            transform.position, vt2, _enemy.stats.speed * Time.deltaTime
        );
        _animController.checkMove(transform.position.x - x);
    }

    public bool isInAttackRange()
    {
        var dis = DistanceCalculator.calculatorDis(transform, playerPosition);

        if (dis <= _atkRange + 1f && Mathf.Abs(transform.position.y - playerPosition.position.y) <= 5.0f)
        {
            return true;
        }
        return false;
    }

    public void moveToTarget()
    {
        if (_playerSensor.isPlayerAround)
        {
            x = playerPosition.position.x;
            y = playerPosition.position.y;

            Movement(x, y);
        }
        else { _animController.checkMove(0); }
    }

    public void EnemyAttack()
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
        float damageDeal = _enemy.stats.attack;
        switch (_currentCombo)
        {
            case 1: damageDeal *= 1f; break;
            case 2: damageDeal *= 2; break;
        }

        if (enity.CompareTag("Player")) { _enemy.Hit(enity.GetComponent<Hero>(), damageDeal); }
    }


    public Vector2 FixedPoint()
    {
        var vector2 = new Vector2();

        if (_animController.isFacingRight)
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(FixedPoint(), _atkRange);
    }
}