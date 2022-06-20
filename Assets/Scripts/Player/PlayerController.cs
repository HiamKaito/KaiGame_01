using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private bool _isControllable = true;
    [SerializeField] private float _movementSpeed = 300.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private bool _isFacingRight = true;
    public bool isFacingRight
    {
        get { return _isFacingRight; }
        set { _isFacingRight = value; }
    }


    [Header("Object interact")]
    public Rigidbody2D _rb2D;
    public Animator animator;
    public PlayerSensor _groundSensor;
    public Hero hero;

    // private unmodified data
    Vector2 movement;

    public static PlayerController instants;


    private void Start()
    {
        instants = this;

        _rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();

        hero = GetComponent<Hero>();
        _movementSpeed = hero.stats.speed;
        _jumpForce = hero.stats.jumpForce;

    }

    private void Update()
    {
        if (_isControllable)
        {
            checkMove();
            checkJump();
            CheckCombo();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }

    [Header("Move")][SerializeField] private float _acceleration = 90;
    [SerializeField] private float _moveClamp = 13;
    [SerializeField] private float _deAcceleration = 60f;
    public void Move()
    {
        float _currentHorizontalSpeed = 0f;
        if (movement.x != 0)
        {
            // Set horizontal move speed
            _currentHorizontalSpeed += movement.x * _acceleration * Time.fixedDeltaTime * _movementSpeed;

            // clamped by max frame movement
            _currentHorizontalSpeed = Mathf.Clamp(_currentHorizontalSpeed, -_moveClamp, _moveClamp);
        }
        else
        {
            // No input. Let's slow the character down
            _currentHorizontalSpeed = Mathf.MoveTowards(_currentHorizontalSpeed, 0, _deAcceleration * Time.fixedDeltaTime);
        }

        _rb2D.velocity = new Vector2(_currentHorizontalSpeed, _rb2D.velocity.y);
        // _rb2D.velocity = new Vector2(movement.x * Time.fixedDeltaTime * _movementSpeed * 10, _rb2D.velocity.y);
    }

    [Header("Gravity")][SerializeField] private float _fallClamp = 30f;

    private void Gravity()
    {
        // is not on ground
        if (!_groundSensor.State())
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _rb2D.velocity.y - _fallClamp * Time.deltaTime);
        }

    }

    //===========================================================================================================================
    //===========================================================================================================================
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void checkMove()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (movement.x != 0)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        checkFlip();
    }

    private void checkFlip()
    {
        if ((_isFacingRight && movement.x < 0) || (!_isFacingRight && movement.x > 0))
        {
            Flip();
        }
    }

    private void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundSensor.State())
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
    }

    public void isDamaged()
    {
        animator.SetTrigger("isDamaged");
    }

    public void Death()
    {
        animator.SetBool("isRun", false);
        _isControllable = false;
        animator.SetBool("isAlive", false);
    }
}
