using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour
{
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject ButtonQuit;
    [SerializeField] GameObject ButtonSetting;
    [SerializeField] GameObject PanelQuit;
    [SerializeField] GameObject PanelQuitDef;
    Quizmanager quizManager;
    private void Start()
    {
        quizManager = FindObjectOfType<Quizmanager>();
        MainPanel.SetActive(true);
        PanelQuit.SetActive(false);
        PanelQuitDef.SetActive(false);
    }
    public void LoadSceneByIndex(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }
    public void Loadpanel(GameObject L_Panel)
    {
        L_Panel.SetActive(true);
    }
    public void LoadpanelWithOpacity(GameObject L_Panel)
    {
        L_Panel.SetActive(true);
        Color color = MainPanel.GetComponent<Image>().color;
        color.a = 0.2f;
        MainPanel.GetComponent<Image>().color = color;
        ButtonQuit.SetActive(false);
        ButtonSetting.SetActive(false);
    }
    public void Continue()
    {
        PanelQuit.SetActive(false);
        Color color = MainPanel.GetComponent<Image>().color;
        color.a = 1f;
        MainPanel.GetComponent<Image>().color = color;
        ButtonQuit.SetActive(true);
        ButtonSetting.SetActive(true);
    }
    public void Home()
    {
        // score should be reset score and load scene Home

        quizManager.score = 0;
        MainPanel.SetActive(true);
        PanelQuit.SetActive(false);
        LoadSceneByIndex(4);
    }
    public void QuitFromQuitPanel()
    {
        PanelQuitDef.SetActive(true);
        PanelQuit.SetActive(false);
    }
    public void Quit()
    {
        PanelQuit.SetActive(true);
        Color color = MainPanel.GetComponent<Image>().color;
        color.a = 0.2f;
        MainPanel.GetComponent<Image>().color = color;
        ButtonQuit.SetActive(false);
        ButtonSetting.SetActive(false);
    }
}
