using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UIController : MonoBehaviour
{
    public Button StartBtn;
    public Button SettingBtn;
    public Label labelTXt;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        StartBtn = root.Q<Button>("Btnstart");
        SettingBtn = root.Q<Button>("Btnsetting");
        labelTXt = root.Q<Label>("lbltxt");

        //Buttons click event 
        StartBtn.clicked += StartbtnPress;
        SettingBtn.clicked += SettingButtonPress;
    }
    void StartbtnPress()
    {
        labelTXt.style.display = DisplayStyle.Flex;
        labelTXt.text = "Is start Button";
    }
    void SettingButtonPress()
    {
        labelTXt.style.display = DisplayStyle.Flex;
        labelTXt.text = "Is Setting Button";
    }
}
