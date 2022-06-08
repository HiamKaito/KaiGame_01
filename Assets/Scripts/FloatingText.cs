using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float _timeDisplay = 0f;
    [SerializeField] private float _axis_X;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _dropRadius = 4.0f;
    [SerializeField] private TextMesh _textMesh;
    [SerializeField] private Style _style = Style.Drop;

    private enum Style
    {
        Drop, BlowUp, ZoomIn
    }


    [Header("Ouptut")]
    [SerializeField] private float speed = 0f;
    [SerializeField] private float _frame = 1.0f, _frameDel = 0.01f;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();

        _axis_X = Random.Range(-0.3f, 0.3f);
        _timeDisplay = _dropRadius / (_speed * 1.5f);


        // _textMesh = transform.Find("TextManage").GetComponent<TextMesh>();
        Destroy(gameObject, _timeDisplay);
    }

    private void FixedUpdate()
    {
        switch (_style)
        {
            case Style.Drop:
                StyleDrop();
                break;
            case Style.BlowUp:
                StyleBlowUp();
                break;
            case Style.ZoomIn:
                StyleZoomIn();
                break;
        }
    }

    public void StyleDrop()
    {
        speed = (_axis_X * Time.fixedDeltaTime * _speed * 10) / Time.fixedDeltaTime;

        _rb2D.velocity = new Vector2(speed, _rb2D.velocity.y);
    }

    public void StyleBlowUp()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().enabled = false;
        speed = (0.1f * Time.fixedDeltaTime * _speed * 10) / Time.fixedDeltaTime;

        _rb2D.velocity = new Vector2(_rb2D.velocity.x, speed);
    }

    public void StyleZoomIn()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().enabled = false;
        speed = (0.1f * Time.fixedDeltaTime * _speed * 5) / Time.fixedDeltaTime;

        _rb2D.velocity = new Vector2(_rb2D.velocity.x, speed);

        var scale = Mathf.Sin(_frame);
        _frame -= _frameDel;

        transform.localScale = new Vector3(
                scale, scale, scale
            );

        if (scale <= 0) { Destroy(gameObject); }
    }

    public void setText(string input)
    {
        _textMesh.text = input;
    }

    public void setText(int input)
    {
        _textMesh.text = input.ToString();
    }

    public void setText(float input)
    {
        _textMesh.text = input.ToString("0.0");
    }


}
