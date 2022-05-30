using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 3.0f;
    [SerializeField] private bool _FacingRight = true;
    public Rigidbody2D _rb2D;
    public PlayerSensor _groundSensor;
    Vector2 movement;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _groundSensor = transform.Find("GroundSensor").GetComponent<PlayerSensor>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player Jump");
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {

        // _rb2D.MovePosition(_rb2D.position + (movement * _movementSpeed * Time.fixedDeltaTime));
        _rb2D.velocity = new Vector2(movement.x * Time.fixedDeltaTime * _movementSpeed, _rb2D.velocity.y);
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("Player Jump");
        //     _rb2D.AddForce(Vector2.up * _jumpForce);
        // }

    }

}
