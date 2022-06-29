using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
