using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private int _deadCount = 0;
    public int DeadCount
    {
        get { return _deadCount; }
    }
    [SerializeField] private bool _isPlayerAlive = true;

    public static GameManagement instants;

    private void Start()
    {
        instants = this;
        DontDestroyOnLoad(this);
    }

    public void dead()
    {
        _deadCount++;
        _isPlayerAlive = false;
    }

    public IEnumerator Restart()
    {
        Debug.Log("Press SPACE");
        int i = 0;
        while (!_isPlayerAlive)
        {
            i++;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isPlayerAlive = true;
                SceneManager.LoadScene("Map_1");
            }

            if (i == 10000) break;
            yield return null;
        }
    }

}
