using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsManager : MonoBehaviour
{
    [SerializeField] Button[] Levelbuttons;

    private void Awake()
    {
        //
        int Reachedlevel = PlayerPrefs.GetInt("Level",0);
        Debug.Log(Reachedlevel);
        for(int i=0;i<Levelbuttons.Length;i++)
        {
            if(i>Reachedlevel)
            {
                Levelbuttons[i].interactable = false;
            }else
            {
                //count start from 0 so lock image is second child should be child 2
                Levelbuttons[i].gameObject.transform.GetChild(2).GetComponent<Image>().sprite=null;
                var Alphavalue = Levelbuttons[i].gameObject.transform.GetChild(2).GetComponent<Image>().color;
                Alphavalue.a = 0f;
                Levelbuttons[i].gameObject.transform.GetChild(2).GetComponent<Image>().color = Alphavalue;
            }
        }
    }
    
}
