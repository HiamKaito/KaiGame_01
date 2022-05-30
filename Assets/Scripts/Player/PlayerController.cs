using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 3.0f;
    [SerializeField] private bool _isFacingRight = true;

    [Header("Object interact")]
    public Rigidbody2D _rb2D;
    public PlayerSensor _groundSensor, _wallSensor;

    Vector2 movement;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();
        _wallSensor = transform.Find("WallSensor").GetComponent<PlayerSensor>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        // InputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _groundSensor.State())
        {
            Debug.Log("Player Jump");
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }

        if ((movement.x > 0 && _wallSensor.State()))
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, Mathf.Clamp(_rb2D.velocity.y, 0f, transform.position.z));
        }

        if (_isFacingRight && movement.x < 0)
        {
            Flip();
        }
        else if (!_isFacingRight && movement.x > 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(movement.x * Time.fixedDeltaTime * _movementSpeed, _rb2D.velocity.y);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

}
