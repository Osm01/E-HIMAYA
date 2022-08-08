using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaseManager : MonoBehaviour
{
   
   
    
    
    public void LoadSceneByIndex(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }
    
}
