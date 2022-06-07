using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerSensor : MonoBehaviour
{
    [SerializeField] private bool _isPlayerAround = false;
    public bool isPlayerAround
    {
        get { return _isPlayerAround; }
        set { _isPlayerAround = value; }
    }
    [SerializeField] private Transform playerPosition;
    public float x, y;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSensor"))
        {
            _isPlayerAround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSensor"))
        {
            _isPlayerAround = false;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
