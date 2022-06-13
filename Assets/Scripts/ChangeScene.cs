using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    enum sceneNames
    {
        Tutorial, Map_1, Map_2
    }

    [SerializeField] private sceneNames _sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(_sceneName.ToString());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            changeScene();
        }
    }
}
