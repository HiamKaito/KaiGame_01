using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Controller : MonoBehaviour
{
    [Header("Enemy Controller")]
    [SerializeField] private Transform playerPosition;
    public float x, y;

    [Space(10)]
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private E_AnimController _animController;
    [SerializeField] private E_PlayerSensor _playerSensor;

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


        if (_playerSensor.isPlayerAround)
        {
            x = playerPosition.position.x;
            y = playerPosition.position.y;

            Movement(x, y);
        }
        else { _animController.checkMove(0); }
    }

    public void Movement(float x, float y)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, transform.position.y), _enemy.stats.speed * Time.deltaTime);
        _animController.checkMove(transform.position.x - x);
    }
}