using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class NabihQST : MonoBehaviour
{
    //[SerializeField] Renderer NabihRender;
    [SerializeField] NabihSaraQst[] Qts;
    [SerializeField] Text PlaceQuestion;
    [SerializeField] Button[] Answers;
    [SerializeField] Animator animator;
    [SerializeField] Animator NabihAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField]
    MultiAimConstraint _MultiAimConstraint;
    [SerializeField] ParticleSystem RainParticleSystem;
    [SerializeField] ParticleSystem ThinkParticleSystem;
    //first clip for correct answer sound and second for wrong sound effect
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] Animator NabihAnimatorController;
    bool IsCorrect;
    int currentQuestion;
    int indexquestion;
    Color defaultColorButton;
    private void Start()
    {
        currentQuestion = 0;
        indexquestion = 0;
        IsCorrect = false;
    }
    private void OnEnable()
    {

    }
    private void Update()
    {

        if (currentQuestion < Qts.Length && currentQuestion == indexquestion)
        {
            // animator.CrossFade("ThinkingIdle", 0.1f);
            ThinkParticleSystem.Play();
            FillQuestionAnswers();
            indexquestion++;
        }

        Debug.Log(IsCorrect);
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
    public void IsAnswerCorrect( int indexx )
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
    IEnumerator CorrectionMethod( int index )
    {
        defaultColorButton = Answers[Qts[currentQuestion].CorrectIndex].GetComponent<Image>().color;
        //make button not interactable and set color green if correct answer and red if it's not correct + play Animation
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].enabled = false;
        }
        if (IsCorrect)
        {
            Answers[Qts[currentQuestion].CorrectIndex].GetComponent<Image>().color = Color.green;
            animator.CrossFade("Happy Idle", 0.1f);
                animator.SetBool("Correct", true);
                NabihAnimator.CrossFade("YesNabih", 0.1f);
                NabihAnimator.SetBool("Yes", true);
            // NabihRender.material.SetTextureScale("_MainTex", new Vector2(1.6f, 1.75f));
            audioSource.PlayOneShot(audioClips[0]);
            
        }
        else
        {
            Answers[index].GetComponent<Image>().color = Color.red;
            animator.CrossFade("Sad Idle", 2f);
            animator.SetBool("Incorrect", true);
            NabihAnimator.CrossFade("NoNqbih", 0.1f);
            NabihAnimator.SetBool("No", true);
            //NabihRender.material.SetTextureScale("_MainTex", new Vector2(2.83f, 2.12f));
            RainParticleSystem.Play();
            audioSource.PlayOneShot(audioClips[1]);
            
        }
        yield return new WaitForSeconds(4);
         animator.SetBool("Correct", false);
         animator.SetBool("Incorrect", false);
         NabihAnimator.SetBool("Yes", false);
         NabihAnimator.SetBool("No", false);
        //NabihRender.material.SetTextureScale("_MainTex", new Vector2(2.8f, 1.74f));
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
            SceneManager.LoadScene(4);
            Debug.Log("Heello");
        }
    }
}

