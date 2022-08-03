using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
public class QuestionManagerScene2 : MonoBehaviour
{
    [SerializeField] QuestionScene2[] Qts;
    [SerializeField] Text PlaceQuestion;
    [SerializeField] Button[] Answers;
    //[SerializeField] AudioSource audioSource;
    [SerializeField] MultiAimConstraint _MultiAimConstraint;
    [SerializeField] GameObject Dialog1Canvas;
    [SerializeField] GameObject QuestionCanvas;
    //[SerializeField] ParticleSystem RainParticleSystem;
    //[SerializeField] ParticleSystem ThinkParticleSystem;
    // first clip for correct answer sound and second for wrong sound effect
    [SerializeField] AudioClip[] audioClips;
    Color defaultColorButton;
    bool IsCorrect;
    int currentQuestion;
    int indexquestion;
    DialogManagerScene2 managerScene2;
    TransitionCameras transitionCameras;
    
    BoyLooking boyLooking;
    private void Start()
    {
      
        currentQuestion = 0;
        indexquestion = 0;
        IsCorrect = false;
        defaultColorButton = Answers[0].GetComponent<Image>().color;
        managerScene2 = FindObjectOfType<DialogManagerScene2>();
        transitionCameras = FindObjectOfType<TransitionCameras>();
    }
    private void OnEnable()
    {
        BoyLooking.LookCamera = true;
        
    }
    private void Update()
    {
        if (currentQuestion < Qts.Length && currentQuestion == indexquestion)
        {
           
            //ThinkParticleSystem.Play();
            FillQuestionAnswers();
            indexquestion++;
        }
        
    }
    void FillQuestionAnswers()
    {
        PlaceQuestion.text = Qts[currentQuestion].Question;
        for (int i = 0; i < Answers.Length; i++)
        {
            // fill answer
            Answers[i].GetComponentInChildren<Text>().text = Qts[currentQuestion].Answers[i];
        }
    }
    public void IsAnswerCorrect(int indexx)
    {

        if (currentQuestion < Qts.Length)
        {
            if (indexx == Qts[currentQuestion].CorrectIndex)
            {
                IsCorrect = true;
            }
            else
            {
                IsCorrect = false;
            }
            StartCoroutine(CorrectionMethod(indexx));

        }

    }
    IEnumerator CorrectionMethod(int index)
    {
        //make button not interactable and set color green if correct answer and red if it's not correct + play Animation
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].enabled = false;
        }
        if (IsCorrect)
        {
            Answers[Qts[currentQuestion].CorrectIndex].GetComponent<Image>().color = Color.green;
           // animator.CrossFade("Happy Idle", 0.1f);
           // animator.SetBool("Correct", true);
           // NabihRender.material.SetTextureScale("_MainTex", new Vector2(1.6f, 1.75f));
           // audioSource.PlayOneShot(audioClips[0]);
        }
        else
        {
            Answers[index].GetComponent<Image>().color = Color.red;
          //  animator.CrossFade("Sad Idle", 2f);
            //animator.SetBool("Incorrect", true);
          //  NabihRender.material.SetTextureScale("_MainTex", new Vector2(2.83f, 2.12f));
           // RainParticleSystem.Play();
           // audioSource.PlayOneShot(audioClips[1]);
        }
        yield return new WaitForSeconds(4);
       // animator.SetBool("Correct", false);
       // animator.SetBool("Incorrect", false);
       // NabihRender.material.SetTextureScale("_MainTex", new Vector2(2.8f, 1.74f));
        // after 4 second reset every thing for next question 
        currentQuestion++;
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].enabled = true;
            Answers[i].GetComponent<Image>().color = defaultColorButton;
        }
        if (currentQuestion == Qts.Length)
        {
            //End Game Here .......
            transitionCameras.switchCam4 = true;
            managerScene2.SwitchCanvas = false;
            Dialog1Canvas.SetActive(true);
            QuestionCanvas.SetActive(false);
        }
    }
}
