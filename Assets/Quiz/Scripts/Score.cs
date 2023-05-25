using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextSpeech;

    public class Score : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI  textfield;
    public Button option1;
    public Button option2;
    public Button option3;
    public GameObject myPanel;



    void Start(){
        textfield.enabled = false;
       option1.gameObject.SetActive(false);
       option2.gameObject.SetActive(false);
       option3.gameObject.SetActive(false);
       myPanel.gameObject.SetActive(false);


       
    }


    public void StartSpeak(string message){
        TextToSpeech.Instance.StartSpeak(message);
    }
   public void setText(string text){
    option1.gameObject.SetActive(true);
    option2.gameObject.SetActive(true);
   option3.gameObject.SetActive(true);
    myPanel.gameObject.SetActive(true);
     textfield.enabled = true;
    textfield.text=text;
    StartSpeak("bienvinue dans le quiz");
    }
     void setup(string code){
        TextToSpeech.Instance.Setting(code,1,1);
    }
}
