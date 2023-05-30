using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class save : MonoBehaviour
{
     public Button interactableButton;
     public Questionmangaer Questionmangaer;
    private int score;
    private bool interactableStatus;
       private void Start()
    {
        // Load the saved status and score on start
        LoadProgress();

        Application.quitting += SaveProgree;

        interactableButton.onClick.AddListener(ToggleInteractable);
    }
    private void OnApplicationQuit()
    {
        // Save the status and score when the app is closed
        SaveProgree();
       
    }
    private void SaveProgree()
    {
        // Save the interactable status
        PlayerPrefs.SetInt("InteractableStatus", interactableButton.interactable ? 1 : 0);
         PlayerPrefs.SetInt("Score", Questionmangaer.score);
        PlayerPrefs.Save();
    }
    private void LoadProgress()
    {
        // Load the interactable status and apply it to the button
        int status = PlayerPrefs.GetInt("InteractableStatus", 1);
                score = PlayerPrefs.GetInt("Score", 0);

        interactableButton.interactable = (status == 1);
    }

 private void ToggleInteractable()
    {
        // Toggle the interactable status of the button
        interactableButton.interactable = !interactableButton.interactable;
    }


    
}
