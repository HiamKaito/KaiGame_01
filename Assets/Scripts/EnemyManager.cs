using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject portalInactive, portalActive;
    public List<Enemy> listEnemy;
    public bool isPressable = false;

    private void Update()
    {
        if (isPressable)
        {
            foreach (var enemy in listEnemy)
            {
                if (enemy == null)
                {
                    listEnemy.Remove(enemy);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && listEnemy.Count == 0)
            {
                portalInactive.SetActive(false);
                portalActive.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPressable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPressable = false;
        }
    }
}
