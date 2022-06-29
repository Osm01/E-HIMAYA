using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeSceneManager : MonoBehaviour
{
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject PanelCategorie;
    [SerializeField] GameObject PanelSetting;
    [SerializeField] GameObject Quitpanel;
    [SerializeField] GameObject QuitDef;
    void Start()
    {
        MainPanel.SetActive(true);
        PanelCategorie.SetActive(false);
        PanelSetting.SetActive(false);
        Quitpanel.SetActive(false);
        QuitDef.SetActive(false);
    }
    public void Jouer()
    {
        MainPanel.SetActive(false);
        PanelCategorie.SetActive(true);
    }
    public void Back()
    {
        MainPanel.SetActive(true);
        PanelCategorie.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadSceneByIndex(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }

}
