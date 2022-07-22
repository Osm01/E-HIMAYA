using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestionManager : MonoBehaviour
{
    [SerializeField] QuestionScript[] Qts;
    [SerializeField] Text PlaceQuestion;
    [SerializeField] Button[] Answers;
    [SerializeField] Animator animator;
    bool IsCorrect;
    int currentQuestion;
    int indexquestion;

    private void Start()
    {
        currentQuestion = 0;
        indexquestion = 0;
        IsCorrect = false;
    }
    private void Update()
    {
        if (currentQuestion < Qts.Length && currentQuestion == indexquestion)
        {
            animator.CrossFade("ThinkingIdle", 0.1f);
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
    IEnumerator CorrectionMethod(int index)
    {
        //make button not interactable and set color green if correct answer and red if it's not correct + play Animation
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].enabled = false;
        }
        if(IsCorrect)
        {
            Answers[Qts[currentQuestion].CorrectIndex].GetComponent<Image>().color = Color.green;
            animator.CrossFade("Happy Idle", 0.1f);
            animator.SetBool("Correct", true);
        }
        else
        {
            Answers[index].GetComponent<Image>().color = Color.red;
            animator.CrossFade("Sad Idle", 0.1f);
            animator.SetBool("Incorrect", true);
        }
        yield return new WaitForSeconds(4);
        animator.SetBool("Correct", false);
        animator.SetBool("Incorrect", false);
        // after 4 second reset every thing for next question 
        currentQuestion++;
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i].enabled = true;
            Answers[i].GetComponent<Image>().color = Color.black;
        }
    }

}
