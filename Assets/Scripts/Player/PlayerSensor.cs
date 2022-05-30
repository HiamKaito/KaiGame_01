using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    [SerializeField] private int _colCount = 0;
    [SerializeField] private float _disableTimer;

    private void OnEnable()
    {
        _colCount = 0;
    }

    public bool State()
    {
        if (_disableTimer > 0) return false;
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _colCount++;
    }

    private void Update()
    {
        _disableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        _disableTimer = duration;
    }
}
