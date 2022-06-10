using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private GameObject _wall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _wall.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
