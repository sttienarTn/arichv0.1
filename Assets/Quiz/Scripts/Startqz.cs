using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextSpeech;
using DG.Tweening;


    public class Startqz : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI  textfield;
    public Button option1;
    public Button option2;
    public Button option3;
    public Button Quizstarter;
    public Button monum1;
    public Button monum2;
    public Button monum3;
    public GameObject myPanel;
    public RectTransform s1,s2,s3;
  

    void Start(){
        textfield.enabled = false;
       option1.gameObject.SetActive(false);
       option2.gameObject.SetActive(false);
       option3.gameObject.SetActive(false);
       myPanel.gameObject.SetActive(false);
       monum1.gameObject.SetActive(false);
       monum2.gameObject.SetActive(false);
      monum3.gameObject.SetActive(false);

       
    }


    public void StartSpeak(string message){
        TextToSpeech.Instance.StartSpeak(message);
    }
   public void StartQuizQuestion(string text){
    option1.gameObject.SetActive(true);
    option2.gameObject.SetActive(true);
   option3.gameObject.SetActive(true);
    myPanel.gameObject.SetActive(true);
     textfield.enabled = true;
    StartSpeak("bienvinue dans le quiz");
       s1.DOAnchorPos(new Vector2(1234, 0),0.25f);
       s2.DOAnchorPos(new Vector2(1234, 0),0.25f);

    }
     void setup(string code){
        TextToSpeech.Instance.Setting(code,1,1);
    }
    public void StartQuizInterface(){
   monum1.gameObject.SetActive(true);
  monum2.gameObject.SetActive(true);
   monum3.gameObject.SetActive(true);
}
}
  

