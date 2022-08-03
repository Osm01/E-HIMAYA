using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class DialogManagerScene2 : MonoBehaviour
{
    //[SerializeField] Renderer NabihRender;
    [SerializeField] DialogueScene2[] dialog;
    [SerializeField] DialogueScene2[] dialog2;
    [SerializeField] Text PlaceTitle;
    [SerializeField] Text PlaceSentence;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] CinemachineVirtualCamera Vcam3;
    [SerializeField] CinemachineVirtualCamera Vcam4;
    [SerializeField] RawImage ImageChar;
    [SerializeField] Texture T_Nabih;
    [SerializeField] Texture T_Ahmed;
    [SerializeField] Texture T_Nada;
    [SerializeField] GameObject DialogCanvas;
    [SerializeField] GameObject QuestionCanvas;
    //[SerializeField] Animator NabihAnimatorController;
    public bool SwitchCanvas;
    // is press for make sure not get error if player press multiple time in screen
    bool isPress;
    int currentDialog;
    int currentSentence;
    int currentAudio;
    int IndexWrite;
    float _timer = 0;
    private void Start()
    {
        // init values
        currentAudio = 0;
        currentSentence = 0;
        currentDialog = 0;
        IndexWrite = 0;
        SwitchCanvas = false;
        QuestionCanvas.SetActive(false);
        isPress = false;
        //set default tiling value to nabih face expression
       // NabihRender.material.SetTextureScale("_MainTex", new Vector2(2.8f, 1.74f));
    }
    void Writer(Text S, string txt)
    {
        S.text = txt.Substring(0, IndexWrite);
    }
    private void Update()
    {
        /////// first dialog and last virtual camera get focus 
        if (currentDialog <= 0 && Vcam3.Priority < 12)
        {
            DialogLogicFunct();
            Debug.Log("123");
        }
        else if (Vcam3.Priority == 12 && Input.touchCount > 0 && isPress == false)
        {
            isPress = true;
            StartCoroutine(DialogLogicFunctWithPress());
        }
        if (currentDialog <= 0 && Vcam4.Priority == 14)
        {
            DialogLogicFunct();
            Debug.Log("1234qwehggggggg");
        }
        else if (Vcam4.Priority == 14 && Input.GetKeyDown(KeyCode.Space) && isPress == false)
        {
            isPress = true;
            StartCoroutine(DialogLogicFunctWithPress());
            Debug.Log("1234qwe");
        }
        if (SwitchCanvas)
        {
            DialogCanvas.SetActive(false);
            QuestionCanvas.SetActive(true);
        }
    }
    void AudioMangerMethod()
    {
        // hard code this part
        // First audio 
        if (!audioSource.isPlaying && currentAudio <= audioClips.Length - 1)
        {
            if (currentDialog == 0 && currentSentence == 0)
            {
                if (currentAudio != 0)
                {

                    return;
                }

                audioSource.PlayOneShot(audioClips[currentAudio]);
                currentAudio++;

            }
            // Second audio 
            if (!audioSource.isPlaying && currentDialog == 1 && currentSentence == 0)
            {
                if (currentAudio != +1)
                {

                    return;
                }

                audioSource.PlayOneShot(audioClips[currentAudio]);
                currentAudio++;

            }
            // third audio
            if (!audioSource.isPlaying && currentDialog == 2 && currentSentence == 0)
            {
                if (currentAudio != 2)
                {

                    return;
                }

                audioSource.PlayOneShot(audioClips[currentAudio]);
                currentAudio++;

            }
            //firth audio
            if (!audioSource.isPlaying && currentDialog == 2 && currentSentence == 1)
            {
                if (currentAudio != 3)
                {

                    return;
                }

                audioSource.PlayOneShot(audioClips[currentAudio]);
                currentAudio++;

            }
            Debug.Log(currentAudio);
        }

    }
    void DialogLogicFunct()
    {
        if (Time.time > _timer)
        {
            if (currentDialog <= dialog.Length - 1)
            {
                if (currentSentence <= dialog[currentDialog].Sentencess.Length - 1)
                {
                    if (IndexWrite <= dialog[currentDialog].Sentencess[currentSentence].Length - 1)
                    {
                        AudioMangerMethod();
                        _timer = Time.time + 0.05f;
                        PlaceTitle.text = dialog[currentDialog].Namee;
                        Writer(PlaceSentence, dialog[currentDialog].Sentencess[currentSentence]);
                        IndexWrite++;
                    }
                    else
                    {
                        IndexWrite = 0;
                        currentSentence++;
                    }
                }
                else
                {
                    currentDialog++;
                    currentSentence = 0;
                    IndexWrite = 0;
                }
            }
        }
    }
    IEnumerator DialogLogicFunctWithPress()
    {

        IndexWrite = 0;
        if (currentDialog <= dialog.Length - 1)
        {
            if (currentSentence <= dialog[currentDialog].Sentencess.Length - 1)
            {
                if (dialog[currentDialog].Namee == "Nabih")
                {
                    ImageChar.texture = T_Nabih;
                    ImageChar.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 350);
                   // NabihAnimatorController.SetBool("Explain", true);
                }
                else if(dialog[currentDialog].Namee == "Nada")
                {
                    ImageChar.texture = T_Nada;
                    ImageChar.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                }else
                {
                    ImageChar.texture = T_Ahmed;
                }
                do
                {
                    AudioMangerMethod();
                    PlaceTitle.text = dialog[currentDialog].Namee;
                    Writer(PlaceSentence, dialog[currentDialog].Sentencess[currentSentence]);
                    IndexWrite++;
                    yield return new WaitForSeconds(0.04f);
                } while (IndexWrite <= dialog[currentDialog].Sentencess[currentSentence].Length);
                currentSentence++;
                IndexWrite = 0;
            //    NabihAnimatorController.SetBool("Explain", false);
            }
            else
            {
                currentSentence = 0;
                currentDialog++;
            }

        }
        else
        {
            currentDialog = 0;
            currentSentence = 0;
            SwitchCanvas = true;
        }
        isPress = false;
    }
}
