using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class DialogManager : MonoBehaviour
{
    [SerializeField] Dialog[] dialog;
    [SerializeField] Text PlaceTitle;
    [SerializeField] Text PlaceSentence;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] CinemachineVirtualCamera Vcam3;
    [SerializeField] RawImage ImageChar;
    [SerializeField] Texture T_Nabih;
    [SerializeField] Texture T_Omar;
    [SerializeField] GameObject DialogCanvas;
    [SerializeField] GameObject QuestionCanvas;
    bool SwitchCanvas;
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
       
    }
    void Writer( Text S, string txt )
    {
        S.text = txt.Substring(0, IndexWrite);
    }
    private void Update()
    {
        /////// first dialog and last virtual camera get focus 
        if (currentDialog <= 0 && Vcam3.Priority < 12)
        {
            DialogLogicFunct();
        }
        else if (Vcam3.Priority==12 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DialogLogicFunctWithPress());
        }
        if(SwitchCanvas)
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
                if (currentAudio != 1)
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
                if (currentSentence <= dialog[currentDialog].Sentences.Length - 1)
                {
                    if (IndexWrite <= dialog[currentDialog].Sentences[currentSentence].Length - 1)
                    {
                        AudioMangerMethod();
                        _timer = Time.time + 0.05f;
                        PlaceTitle.text = dialog[currentDialog].Name;
                        Writer(PlaceSentence, dialog[currentDialog].Sentences[currentSentence]);
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
            if (currentSentence <= dialog[currentDialog].Sentences.Length - 1)
            {
                if (dialog[currentDialog].Name == "Nabih")
                {
                    ImageChar.texture = T_Nabih;
                    ImageChar.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 350);
                }
                else
                {
                    ImageChar.texture = T_Omar;
                    ImageChar.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                }
                do
                {
                    AudioMangerMethod();
                    PlaceTitle.text = dialog[currentDialog].Name;
                    Writer(PlaceSentence, dialog[currentDialog].Sentences[currentSentence]);
                    IndexWrite++;
                    yield return new WaitForSeconds(0.04f);
                } while (IndexWrite <= dialog[currentDialog].Sentences[currentSentence].Length - 1);
                currentSentence++;
                IndexWrite = 0;
            }
            else
            {
                currentSentence = 0;
                currentDialog++;
            }

        }else
        {
            SwitchCanvas = true;
        }

    }
}

