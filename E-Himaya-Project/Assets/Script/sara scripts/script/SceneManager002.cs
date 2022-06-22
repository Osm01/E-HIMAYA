using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager002 : MonoBehaviour
{
    public GameObject Main_panels;
    public GameObject  levels_panel;
    public GameObject[] levels;
    int maximum_level = 1;
    void Start()
    {
        if(PlayerPrefs.HasKey("max_level"))
        {
            maximum_level = PlayerPrefs.GetInt("max_level");
        }
        else
        {
            PlayerPrefs.SetInt("max_level", 1);
        }
        for (int i=1;i<= levels.Length; i++)
        {
            if (i <= maximum_level)
            {
                levels[i - 1].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                levels[i - 1].transform.GetChild(0).GetComponent<Text>().color = Color.yellow;
                Destroy(levels[i - 1].GetComponent<Button>());
            }


        }
    }
    public void GoToMenu(int level_number)
    {
        PlayerPrefs.SetInt("current_level", level_number);
        SceneManager.LoadScene("connaissance en cybersecurity 1");

    }
    public void Showlevels()
    {
        levels_panel.SetActive(true);
        Main_panels.SetActive(false);
    }
    public void ShowMenu()
    {
        levels_panel.SetActive(false);
        Main_panels.SetActive(true);
    }
  
}
