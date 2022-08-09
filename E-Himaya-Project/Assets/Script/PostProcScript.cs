using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcScript : MonoBehaviour
{
    PostProcessVolume processVolume;
    float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        processVolume = this.gameObject.GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntensityOFVignette();
    }
    void ChangeIntensityOFVignette()
    {
        if (_timer < Time.time)
        {
            _timer = Time.time + 0.1f;
            processVolume.profile.GetSetting<Vignette>().intensity.value -= 0.02f;
        }
    }
}
