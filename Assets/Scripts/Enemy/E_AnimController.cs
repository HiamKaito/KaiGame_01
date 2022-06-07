using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class E_AnimController : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] private float _movementSpeed = 999.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private bool _isFacingRight = true;

    [Header("Object interact")]
    public Rigidbody2D _rb2D;
    public Animator animator;
    public PlayerSensor _groundSensor;
    public Enemy enemy;

    // private unmodified data
    Vector2 movement;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();

        enemy = GetComponent<E_Goblin>();
        if (enemy == null)
        {
            // find another class
            enemy = GetComponent<E_Mushroom>();
        }

        _movementSpeed = enemy.stats.speed;
    }

    private void FixedUpdate() => _rb2D.velocity = new Vector2(
        movement.x * Time.fixedDeltaTime * _movementSpeed * 10, _rb2D.velocity.y
    );

    //===========================================================================================================================
    //===========================================================================================================================
    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void checkMove(float axis_x)
    {
        if (axis_x != 0) { animator.SetBool("isRun", true); }
        else { animator.SetBool("isRun", false); }

        checkFlip(axis_x);
    }

    public void checkFlip(float axis_x)
    {
        if ((_isFacingRight && axis_x < 0) || (!_isFacingRight && axis_x > 0)) { Flip(); }
    }

    public void checkJump(bool flag)
    {
        if (flag && _groundSensor.State()) { _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce); }
    }

    public void Death()
    {
        animator.SetBool("isAlive", false);
    }

    public void isDamaged()
    {
        animator.SetTrigger("isDamaged");
    }
}
