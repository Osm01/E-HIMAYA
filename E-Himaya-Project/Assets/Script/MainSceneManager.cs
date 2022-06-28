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
}
