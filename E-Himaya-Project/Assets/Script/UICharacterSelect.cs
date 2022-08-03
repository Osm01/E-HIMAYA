using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICharacterSelect : MonoBehaviour
{
    [SerializeField] Image BorderBoy;
    [SerializeField] Image BorderGirl;
    [SerializeField] Color colorBorderBoy;
    [SerializeField] Color colorBordergirl;
    [SerializeField] GameObject Boy;
    [SerializeField] Animator BoyAnimator;
    [SerializeField] GameObject Girl;
    [SerializeField] Animator GirlAnimator;
    bool isPressedGender;
    private void Start()
    {
        isPressedGender = false;
    }
    // indexx help just to know if player press on boy or girl ---> [NB:-->(0 for boy and 1 for girl)]
    public void SelectGender(int indexx)
    {
        isPressedGender = !isPressedGender;
        if(isPressedGender)
        {
            if (indexx == 0)
            {
                colorBorderBoy.a = 255f;
                BorderBoy.color = colorBorderBoy;
                Boy.SetActive(true);
                BoyAnimator.Play(0);
                //in case not active both girl and boy
                if(Girl.active)
                {
                    Girl.SetActive(false);
                    BorderGirl.color = Color.white;
                    Girl.SetActive(false);
                }
            }
            else
            {
                colorBordergirl.a = 255f;
                BorderGirl.color = colorBordergirl;
                Girl.SetActive(true);
                GirlAnimator.Play(0);
                //in case not active both girl and boy
                if (Boy.active)
                {
                    Boy.SetActive(false);
                    BorderBoy.color = Color.white;
                    Boy.SetActive(false);
                }
            }
        }else
        {
            if (indexx == 0)
            {
                BorderBoy.color = Color.white;
                Boy.SetActive(false);
            }
            else
            {
                BorderGirl.color = Color.white;
                Girl.SetActive(false);
            }
        }
        
    }
    public void PlayGame()
    {
        if(Boy.active || Girl.active)
        {
            //switch to library 
            Debug.Log("Play");
        }else
        {
            Debug.Log("Not Play");
        }
    }
}
