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
    [SerializeField] Animator NabihAnimator;
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
        StartCoroutine(PlayAnimationNabih());
    }
    public void Back()
    {
        MainPanel.SetActive(true);
        PanelCategorie.SetActive(false);
    }
    public void Quit()
    {
        QuitDef.SetActive(true);
    }
    public void LoadSceneByIndex(int IndexScene)
    {
        SceneManager.LoadScene(IndexScene);
    }
    public void Setting()
    {
        PanelSetting.SetActive(true);
    }
    public void back2Menu()
    {
        PanelSetting.SetActive(false);
    }
    public void Yes_QuitDefff()
    {
        Debug.Log("yes ");
        Application.Quit();
    }
    public void No_QuitDefff()
    {
        QuitDef.SetActive(false);
    }
    IEnumerator PlayAnimationNabih()
    {
        NabihAnimator.CrossFade("mixamo_com", 0.1f);
        yield return new WaitForSeconds(3f);
        NabihAnimator.SetBool("Play", false);
        MainPanel.SetActive(false);
        PanelCategorie.SetActive(true);
    }
}
