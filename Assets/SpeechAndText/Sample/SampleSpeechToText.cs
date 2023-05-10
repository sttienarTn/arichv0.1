using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using UnityEngine.Android;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class SampleSpeechToText : MonoBehaviour
{
    public bool isShowPopupAndroid = true;
    public GameObject loading;
    public Toggle toggleShowPopupAndroid;
    public string resultat_var;
    public string _data;
    void Start()
    {
        Setting("fr-FR");
        loading.SetActive(false);                
        TextToSpeech.Instance.StartSpeak("salut je suis arich comme je peux vous aider");
        SpeechToText.Instance.onResultCallback = OnResultSpeech;
#if UNITY_ANDROID
        SpeechToText.Instance.isShowPopupAndroid = isShowPopupAndroid;
        toggleShowPopupAndroid.isOn = isShowPopupAndroid;
        toggleShowPopupAndroid.gameObject.SetActive(true);
        Permission.RequestUserPermission(Permission.Microphone);
#else
        toggleShowPopupAndroid.gameObject.SetActive(false);
#endif

    }


    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.Instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.Instance.StopRecording();
#endif
#if UNITY_IOS
        loading.SetActive(true);
#endif
    }
    public void OnResultSpeech(string _data)
    {
        resultat_var="test passer";
        TextToSpeech.Instance.StartSpeak("vous aver dit "+"responseMessage"+resultat_var);//_data string mta3 text to speech ily bch taadeha lel AI dyalak 
#if UNITY_IOS
        loading.SetActive(false);
#endif
    }
public void OnClickSpeak()
    {
        // Define the API endpoint
        string url = "http://localhost:8000/chatbot";

        // Create a message to send to the chatbot
        var message = new { text = _data };

        // Convert the message to a JSON string
        string json = JsonSerializer.Serialize(message);

        // Create an HTTP client
        using var client = new HttpClient();

        // Send the message to the chatbot
        var response = client.PostAsync(url, new StringContent(json)).Result;

        // Read the response from the chatbot
        var responseString = response.Content.ReadAsStringAsync().Result;

        // Convert the response to a dictionary
        var responseDict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseString);

        // Get the response message
        var responseMessage = responseDict["response"];

        

       TextToSpeech.Instance.StartSpeak(responseMessage);  // 7ot string mta3 speech to text hne 
    } 

     
    
    /// <summary>
    /// </summary>
    public void  OnClickStopSpeak()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    /// <summary>
    /// </summary>
    /// <param name="code"></param>
    public void Setting(string code)
    {
        SpeechToText.Instance.Setting(code);
        TextToSpeech.Instance.Setting(code, 1, 1);
    }

    /// <summary>
    /// Button Click
    /// </summary>


    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    public void OnToggleShowAndroidPopupChanged(bool value)
    {
        isShowPopupAndroid = value;
        SpeechToText.Instance.isShowPopupAndroid = isShowPopupAndroid;
    }
    }

