using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float _timeDisplay = 0f;
    [SerializeField] private float _axis_X;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _dropRadius = 4.0f;

    [SerializeField] private GameObject _bloodDrop;
    [SerializeField] private GameObject _bloodOnGround;


    [Header("Ouptut")]
    [SerializeField] private float speed = 0f;
    [SerializeField] private bool _isOnGround = false;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        _axis_X = Random.Range(-0.3f, 0.3f);
        _timeDisplay = _dropRadius / _speed;

        Destroy(gameObject, _timeDisplay);
    }

    private void FixedUpdate()
    {
        if (!_isOnGround)
        {
            speed = (_axis_X * Time.fixedDeltaTime * _speed * 10) / Time.fixedDeltaTime;
            _rb2D.velocity = new Vector2(speed, _rb2D.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            //* Do something when blood on ground
            _bloodDrop.SetActive(false);
            _bloodOnGround.SetActive(true);

            _isOnGround = true;
            _rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
