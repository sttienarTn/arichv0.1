using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class Questionmangaer : MonoBehaviour
{
   public List<Qustionsandanswer> QnA;
   public GameObject[] options;
   public int currentQuestion;

    public TMPro.TextMeshProUGUI Questiontxt;

   private void Start(){
   generateQuestion();
   }
   public void corret(){
    QnA.RemoveAt(currentQuestion);
    generateQuestion();

   }
   void SetAnswer(){
    for(int i=0;i<options.Length;i++){
        options[i].GetComponent<answer>().isCorrect=false;
        options[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text=QnA[currentQuestion].Answer[i];
       if(QnA[currentQuestion].CorrectAnswer==i+1)
       {
                options[i].GetComponent<answer>().isCorrect=true;

       }
    }
   }

   public void generateQuestion(){
    currentQuestion=Random.Range(0,QnA.Count);
    Questiontxt.text=QnA[currentQuestion].Question;
    SetAnswer();

   }
}
