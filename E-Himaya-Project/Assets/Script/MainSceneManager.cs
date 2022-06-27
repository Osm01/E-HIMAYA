using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneManager : MonoBehaviour
{
    public void LoadSceneByIndex(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }
    public void Loadpanel(GameObject L_Panel)
    {
        L_Panel.SetActive(true);
    }
}
