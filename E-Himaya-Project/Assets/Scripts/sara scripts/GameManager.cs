using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Text level_text;
    // Start is called before the first frame update
    void Start()
    {
        level_text.text = "Categorie" + PlayerPrefs.GetInt("current_level").ToString();
    }

    // Update is called once per frame
   
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
       PlayerPrefs.SetInt("Categorie", PlayerPrefs.GetInt("current_level") + 1);
        if (PlayerPrefs.GetInt("Categorie") > PlayerPrefs.GetInt("max_level")) PlayerPrefs.SetInt("max_level", PlayerPrefs.GetInt("current_level") + 1);
        SceneManager.LoadScene("Game");

    }

}
