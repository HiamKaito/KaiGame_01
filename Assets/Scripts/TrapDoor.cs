using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private GameObject _wallAppear;
    [SerializeField] private GameObject _wallDisappear;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_wallAppear != null) { _wallAppear.SetActive(true); }
            if (_wallDisappear != null) { _wallDisappear.SetActive(false); }

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
