using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Android;
using TextSpeech;
using MongoDB.Driver;
using MongoDB.Bson;

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
    public delegate void GameOverDelegate();
    public static event GameOverDelegate OnGameOver;
    public string collectionName;
    private bool isGameOver = false; // Flag to check if the game is over

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    private void Start()
    {
        scoretxt.SetText("score:0");

        string connectionString = "mongodb+srv://Admin:user@cluster0.wukfony.mongodb.net/";
        string databaseName = "test";
         collectionName = "Theater";

        client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);
        collection = database.GetCollection<BsonDocument>(collectionName);

        FetchQuestionsAndAnswers();
        foreach (var qa in QnA)
        {   
            Debug.Log("Question: " + qa.Question);
            Debug.Log("Answers: " + string.Join(", ", qa.Answer));
            Debug.Log("Correct Answer: " + qa.CorrectAnswer);
              Debug.Log("Quiz " + qa.Quiz);
            
        }
    }

    private void FetchQuestionsAndAnswers()
    {
        // Fetch data from MongoDB
        var documents = collection.Find(new BsonDocument()).ToList();

        // Store fetched data in QnA list
        foreach (var document in documents)
        {
            Qustionsandanswer qa = new Qustionsandanswer();
            qa.Quiz= document.GetValue("Quiz").AsString;
            qa.Question = document.GetValue("question").AsString;
            BsonArray answerArray = document.GetValue("options").AsBsonArray;
            qa.Answer = new string[answerArray.Count];
            for (int i = 0; i < answerArray.Count; i++)
            {
                qa.Answer[i] = answerArray[i].AsString;
            }
            qa.CorrectAnswer = document.GetValue("correctAnswer").ToInt32();

            QnA.Add(qa);
        }
    }

    public void corret()
    {
        if (isGameOver)
            return; // Ignore if the game is already over

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
        {
            gameover();
        }
    }

    public void wrong()
{
    if (isGameOver)
        return; // Ignore if the game is already over

    // Change button color
    options[QnA[currentQuestion].CorrectAnswer].GetComponent<Image>().color = Color.green;

    for (int i = 0; i < options.Length; i++)
    {
        if (i != QnA[currentQuestion].CorrectAnswer && i < options.Length)
        {
            options[i].GetComponent<Image>().color = wrongColor;
            characterAnimator.SetTrigger("angry");
        }
    }

    QnA.RemoveAt(currentQuestion);

    if (QnA.Count > 0)
    {
        StartCoroutine(GenerateQuestionWithDelay(3f));
    }
    else
    {
        gameover();
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

        if (QnA[currentQuestion].CorrectAnswer >= 0 && QnA[currentQuestion].CorrectAnswer < QnA[currentQuestion].Answer.Length)
        {
            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[QnA[currentQuestion].CorrectAnswer].GetComponent<answer>().isCorrect = true;
            }
        }
        else
        {
            Debug.LogError("Invalid CorrectAnswer index: " + QnA[currentQuestion].CorrectAnswer);
        }

        // Reset button color to default
        options[i].GetComponent<Image>().color = defaultColor;
        Debug.Log("color changed");
    }
}


    public void generateQuestion()
    {
        if (isGameOver)
            return; // Ignore if the game is already over

        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            Debug.Log("Current Question Index: " + currentQuestion);
            Questiontxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            gameover();
        }
    }

    public void gameover()
    {
        if (isGameOver)
            return; // Ignore if the game is already over

        isGameOver = true;

        Questiontxt.SetText("Bien jouer");

        if (OnGameOver != null)
        {
            OnGameOver.Invoke();
            Debug.Log("OnGameOver event triggered");
        }
    }
    public void change(string Quiz)
{
    string newCollectionName = Quiz; // Set the new collection name

    // Update the collection name
    collectionName = newCollectionName;

    // Get the new collection using the updated name
    collection = database.GetCollection<BsonDocument>(collectionName);
            FetchQuestionsAndAnswers();

}
}
