using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCategory : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentCategory;
    private void Awake()
    {
        SelectCategory(0);
    }
    private void SelectCategory(int _index)
    {
        previousButton.interactable = ( _index != 0);
        nextButton.interactable = (_index != transform.childCount - 1); 
        for (int i = 0;i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(1 == _index);
        }
    }

    public void ChangeCategory(int _change)
    {
        currentCategory += _change;
        SelectCategory(currentCategory);

    }
}
