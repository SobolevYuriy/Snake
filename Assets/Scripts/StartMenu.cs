using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void SceneStart()
    {
        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1f;

    }
}
