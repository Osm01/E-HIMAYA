using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchImage : MonoBehaviour
{
    public GameObject[] Category;
    int index;
    private void Start()
    {
        index = 0;
    }
    private void Update()
    {
        if (index >= 3)
            index = 3;
        if (index < 0)
            index = 0;
        if(index == 0)
        {
            Category[0].SetActive(true);
        }
    }
    public void Next()
    {
        if (index < Category.Length)
        {
            index += 1;
        }
        for(int i = 0; i < Category.Length; i++)
        {
            Category[i].SetActive(false);
            Category[index].SetActive(true);
        }
        Debug.Log(index);

    }
    public void Previous()
    {
        if (index > 0)
        { 
       index -= 1;
        }
        for (int i = 0; i > Category.Length; i++)
        {
            Category[i].SetActive(true);
            Category[i].SetActive(false);
        }
        Debug.Log(index);
    }
}
