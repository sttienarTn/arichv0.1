using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextSpeech;
using DG.Tweening;

public class Startqz : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI textfield;
    public Button option1;
    public Button option2;
    public Button option3;
    public Button Quizstarter;
    public Button monum1;
    public Button monum2;
    public Button monum3;
    public GameObject myPanel;
    public RectTransform s1, s2, s3;
    public Questionmangaer quest;
  private int clickCount = 0;
private int Clik=0;
    private bool monum1Clicked;
    private bool monum2Clicked;
    private bool monum3Clicked;

    void Start()
    {
        textfield.enabled = false;
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        myPanel.gameObject.SetActive(false);
        monum1.gameObject.SetActive(false);
        monum2.gameObject.SetActive(false);
        monum3.gameObject.SetActive(false);

        monum1Clicked = false;
        monum2Clicked = false;
        monum3Clicked = false;
    }

    public void StartSpeak(string message)
    {
        TextToSpeech.Instance.StartSpeak(message);
    }

    public void StartQuizQuestion(bool act)
    {
        option1.gameObject.SetActive(act);
        option2.gameObject.SetActive(act);
        option3.gameObject.SetActive(act);
        myPanel.gameObject.SetActive(act);
        textfield.enabled = act;
    }

    public void StartQuizInterface()
    {
        monum1.gameObject.SetActive(!monum1.gameObject.activeSelf);
        monum2.gameObject.SetActive(!monum2.gameObject.activeSelf);
        monum3.gameObject.SetActive(!monum3.gameObject.activeSelf);
        monum3.interactable = false;
        monum1.interactable = false;
    }

    private void OnEnable()
    {
        monum1.onClick.AddListener(Monum1Click);
        monum2.onClick.AddListener(Monum2Click);
        monum3.onClick.AddListener(Monum3Click);
    }

    private void OnDisable()
    {   monum1.onClick.RemoveListener(Monum1Click);
        monum2.onClick.RemoveListener(Monum2Click);
        monum3.onClick.RemoveListener(Monum3Click);
    }

    private void Monum1Click()
    {
        // Set the flag for monum1 button clicked
        monum1Clicked = true;

        // Perform desired action for Monum1 button click
        Debug.Log("Monum1 button clicked!");
    }


private void Monum2Click()
{
    clickCount++;

    if (clickCount == 1)
    {
        // Actions to perform on the first click
        s3.DOAnchorPos(new Vector2(1234, 0), 0.25f);
        s1.DOAnchorPos(new Vector2(1234, 0), 0.25f);

        Vector3 targetPosition = new Vector3(707.50732421875f, 2549.74853515625f, 0.0f);
        Vector3 currentScale = s1.transform.localScale;
        Vector3 targetScale = currentScale * 0.5f;

        s2.transform.DOMove(targetPosition, 0.25f);
        s2.transform.DOScale(targetScale, 0.25f);
       quest.change("byrsa");
        quest.generateQuestion();
         StartQuizQuestion(true);
       TextToSpeech.Instance.StartSpeak("bienvenue dans la quiz le byrsa");


        Debug.Log("First click action!");
    }
    else if (clickCount % 2 == 0)
    {
          s3.DOAnchorPos(new Vector2(0.00099182f,265), 0.25f);
        s1.DOAnchorPos(new Vector2(0.00099182f,-47f), 0.25f);
        s2.DOAnchorPos(new Vector2(0.0009182f,542.7f),0.25f);
         Vector3 currentScale = s1.transform.localScale;
        Vector3 targetScale = currentScale * 1f;
        s2.transform.DOScale(targetScale, 0.25f);
        StartQuizQuestion(false);
        Debug.Log("Subsequent click action!");
    }
    else
    {
        s3.DOAnchorPos(new Vector2(1234, 0), 0.25f);
        s1.DOAnchorPos(new Vector2(1234, 0), 0.25f);

        Vector3 targetPosition = new Vector3(707.50732421875f, 2549.74853515625f, 0.0f);
        Vector3 currentScale = s1.transform.localScale;
        Vector3 targetScale = currentScale * 0.5f;

        s2.transform.DOMove(targetPosition, 0.25f);
        s2.transform.DOScale(targetScale, 0.25f);
                  StartQuizQuestion(true);

        Debug.Log("Odd-numbered click action!");
    }
}

    private void Monum3Click()
    {
         Clik ++;
        // Set the flag for monum3 button clicked
        monum3Clicked = true;
    if (Clik == 1)
    {
     s1.DOAnchorPos(new Vector2(1234, 0), 0.25f);
     s2.DOAnchorPos(new Vector2(1234, 0), 0.25f);
      Vector3 targetPosition = new Vector3(707.50732421875f, 2549.74853515625f, 0.0f);
        Vector3 currentScale = s1.transform.localScale;
       Vector3 targetScale = currentScale * 0.5f;

// Move the object to the target position over a specified duration
s3.transform.DOMove(targetPosition, 0.25f);

// Scale the object to the target scale over the same duration
s3.transform.DOScale(targetScale, 0.25f);
            quest.change("Theater");
            quest.generateQuestion();
            StartQuizQuestion(true);
           TextToSpeech.Instance.StartSpeak("bienvenue dans la quiz theater");

           Debug.Log("Monum3 button clicked!");}
           else if (Clik % 2 == 0)
    {
        s3.DOAnchorPos(new Vector2(0.00099182f,265), 0.25f);
        s1.DOAnchorPos(new Vector2(0.00099182f,-47f), 0.25f);
        s2.DOAnchorPos(new Vector2(0.0009182f,542.7f),0.25f);
         Vector3 currentScale = s1.transform.localScale;
        Vector3 targetScale = currentScale * 1f;
        s3.transform.DOScale(targetScale, 0.25f);
        StartQuizQuestion(false);
        Debug.Log("Subsequent click action!");
    }
    else
    {
         s1.DOAnchorPos(new Vector2(1234, 0), 0.25f);
     s2.DOAnchorPos(new Vector2(1234, 0), 0.25f);
      Vector3 targetPosition = new Vector3(707.50732421875f, 2549.74853515625f, 0.0f);
        Vector3 currentScale = s1.transform.localScale;
       Vector3 targetScale = currentScale * 0.5f;

// Move the object to the target position over a specified duration
s3.transform.DOMove(targetPosition, 0.25f);

// Scale the object to the target scale over the same duration
s3.transform.DOScale(targetScale, 0.25f);
         
            StartQuizQuestion(true);

           Debug.Log("Monum3 button clicked!");}
    
    }
}
