using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class UI_Setting : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    [SerializeField] AudioMixer audioMixer;
    private void Start()
    {
        // 1 for meduim quality by default
        dropdown.value = 1;
        QualitySettings.SetQualityLevel(dropdown.value);
        dropdown.onValueChanged.AddListener(delegate { DropDownitemSelect(); });
    }
    void DropDownitemSelect()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
    }
    public void SetVolume(float v)
    {
        audioMixer.SetFloat("Volume", v);
    }
}
