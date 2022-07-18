using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class AnswerScript001 : MonoBehaviour
{
   public bool isCorrect = false;
    public Quizmanager quizmanager;
    public Color startColor;
    int XO = 0;
    private void Start()
    {
       
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        StartCoroutine(ColorTime());
    }
    IEnumerator ColorTime()
    {
        if (isCorrect)
        {
            FillCorrectAnswerLogo(quizmanager.CorrectLogo);
            GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(2);
            quizmanager.Correct();
        }
        else
        {
            quizmanager.txtCorrection.text = quizmanager.QnA[quizmanager.CurrentQuestion].StringCorrectAnswer;
            FillHeartByAnswer(quizmanager.EmptyHeart);
            FillCorrectAnswerLogo(quizmanager.InCorrect);
            GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(1);
            quizmanager.PanelForCorrection.SetActive(true);
            yield return new WaitForSeconds(1);
            quizmanager.Wrong();
            quizmanager.PanelForCorrection.SetActive(false);
        }
        for (int i = 0; i < quizmanager.options.Length; i++)
        {
            quizmanager.options[i].GetComponent<Image>().color = Color.yellow;
        }
    }
    void FillCorrectAnswerLogo(Sprite sprite)
    {
        for (int i = 0; i < quizmanager.ListCorrectPos.Length; i++)
        {
            if (quizmanager.ListCorrectPos[i].GetComponent<Image>().sprite == null)
            {
                var MainColorAnswer = quizmanager.ListCorrectPos[i].GetComponent<Image>().color;
                MainColorAnswer.a = 1f;
                quizmanager.ListCorrectPos[i].GetComponent<Image>().sprite = sprite;
                quizmanager.ListCorrectPos[i].GetComponent<Image>().color = MainColorAnswer;
                break;
            }
        }

    }
    void FillHeartByAnswer(Sprite sprite)
    {
        for (int i = 0; i < quizmanager.ListCorrectPos.Length; i++)
        {
            if (quizmanager.ListHearth[i].GetComponent<Image>().sprite == quizmanager.FillHeart)
            {
                quizmanager.ListHearth[i].GetComponent<Image>().sprite = sprite;
                break;
            }
        }
    }

}
