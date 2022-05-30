using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    [SerializeField] private bool _isTouched = false;

    private void OnEnable()
    {
        this._isTouched = true;
    }

    public bool State()
    {
        return this._isTouched;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground") { this._isTouched = true; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground") { this._isTouched = false; }
    }

}
