using UnityEngine;
using UnityEngine.UI;
public class test : MonoBehaviour
{       public Button[] buttons;
       private int currentIndex = 0; // Current index of the button
        private void SetNextButtonInteractability()
    {
        if (currentIndex >= 0 && currentIndex < buttons.Length)
        {
            buttons[currentIndex].interactable = true; // Set the current button as interactable
            currentIndex++; // Increment the current index
        }
    }
     private void OnEnable()
    {
        Questionmangaer.OnGameOver += StartInstruction;
    }

    private void OnDisable()
    {
        Questionmangaer.OnGameOver -= StartInstruction;
    }

    private void StartInstruction()
    {
        SetNextButtonInteractability();
        Debug.Log("game over");
        // Perform any necessary actions here
    }
}
