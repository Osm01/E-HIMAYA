/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] RectTransform Fader;
    private void Start()
    {
        Fader.gameObject.SetActive(true);
        //LeanTween.scale(Fader, new Vector3(1, 1, 1), 0);
        //LeanTween.scale(Fader, Vector3.zero, 0.5f).setOnComplete(() =>
       //{
           Fader.gameObject.SetActive(false);
       //});
    }
    public void OpenMenuScene()
    {
        Fader.gameObject.SetActive(true);
        LeanTween.scale(Fader, Vector3.zero, 0f);
        LeanTween.scale(Fader, new Vector3(1, 1, 1), 2f).setOnComplete(() =>
        {
           // SceneManager.LoadScene(0);
        });
    }
    public void OpenGameScene ()
    {
        //Fader.gameObject.SetActive(true);
        //LeanTween.scale(Fader, Vector3.zero, 0f);
        //LeanTween.scale(Fader, new Vector3(1, 1, 1), 3f).setOnComplete(() =>
       // {
            SceneManager.LoadScene(1);
        //});
        


    }
}*/
