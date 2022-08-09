using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    Quizmanager quizManager;
    private void Start()
    {
        quizManager = GameManager.FindObjectOfType<Quizmanager>();
    }
    private void Update()
    {
        if(quizManager.score>=5)
        {
            if(SceneManager.GetActiveScene()==SceneManager.GetSceneByBuildIndex(0))
            {
                PlayerPrefs.SetInt("Level",1);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
            {
                PlayerPrefs.SetInt("Level", 2);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                PlayerPrefs.SetInt("Level", 3);
            }
        }
    }
}
