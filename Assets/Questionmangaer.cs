using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Android;
using TextSpeech;

public class Questionmangaer : MonoBehaviour
{
    public Button option1;
    public Button option2;
    public Button option3;
    public List<Qustionsandanswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int score;
    public TMPro.TextMeshProUGUI Questiontxt;
    public TMPro.TextMeshProUGUI scoretxt;
    public Color defaultColor;
    public Color wrongColor = Color.red;
    public Animator characterAnimator;


    private void Start()
    {
       
        generateQuestion();
        scoretxt.SetText("score:0");
      
    }

    public void corret()
    {
        score += 1;
        scoretxt.SetText("score:" + score);

        // Change button color
        options[QnA[currentQuestion].CorrectAnswer].GetComponent<Image>().color = Color.green;
         characterAnimator.SetTrigger("Clapping");

        QnA.RemoveAt(currentQuestion);

        if (QnA.Count > 0)
        {
            StartCoroutine(GenerateQuestionWithDelay(3f));
        } 
          else
        {            gameover();
}
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
    
        // Change button color
        options[QnA[currentQuestion].CorrectAnswer].GetComponent<Image>().color = Color.green;
        for (int i = 0; i < options.Length; i++)
        {
            if (QnA[currentQuestion].CorrectAnswer != i)
            {
                options[i].GetComponent<Image>().color = wrongColor;
                characterAnimator.SetTrigger("angry");
            }
        }

        if (QnA.Count > 0)
        {
            StartCoroutine(GenerateQuestionWithDelay(3f));
        }
        else
        {            gameover();
}
        
    }

    IEnumerator GenerateQuestionWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        generateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<answer>().isCorrect = true;
            }

            // Reset button color to default
            options[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            Debug.Log("Current Question Index: " + currentQuestion);
            Questiontxt.text = QnA[currentQuestion].Question;
            TextToSpeech.Instance.StartSpeak("salut je suis arich comme je peux vous aider");
            SetAnswer();
        }
        else
        {

            gameover();
                }
    }
   public void gameover(){
            scoretxt.SetText("game over test");

   }
}
