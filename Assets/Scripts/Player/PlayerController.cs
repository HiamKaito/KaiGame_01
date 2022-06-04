using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float _movementSpeed = 300.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private bool _isFacingRight = true;

    [Header("Object interact")]
    public Rigidbody2D _rb2D;
    public Animator animator;
    public PlayerSensor _groundSensor;
    public Hero hero;

    // private unmodified data
    Vector2 movement;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();

        hero = GetComponent<Hero>();
        _movementSpeed = hero.stats.speed;
        _jumpForce = hero.stats.jumpForce;

    }

    private void Update()
    {

        checkMove();
        checkJump();
        CheckCombo();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(movement.x * Time.fixedDeltaTime * _movementSpeed * 10, _rb2D.velocity.y);
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

        checkFlpi();
    }

    private void checkFlpi()
    {
        if (_isFacingRight && movement.x < 0)
        {
            Flip();
        }
        else if (!_isFacingRight && movement.x > 0)
        {
            Flip();
        }
    }

    private void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundSensor.State())
        {
            Debug.Log("Player Jump");
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
    }

}
