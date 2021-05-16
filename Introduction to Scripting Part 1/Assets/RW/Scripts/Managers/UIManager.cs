using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //reference to the UIManager
    public Text sheepSavedText;       //reference to the Text component of SavedSheepText
    public Text sheepDroppedText;     //reference to the Text component of DroppedSheepText
    public GameObject gameOverWindow; //reference to the Game Over Window

    // Awake is the first to be called (it's used to set references)
    void Awake()
    {
        Instance = this;
    }

    // Show the number of sheep that are saved 
    public void UpdateSheepSaved()
    {
        //Convert the GameStateManager counter to String
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    // Show the number of sheep that dropped
    public void UpdateSheepDropped()
    {
        //Convert the GameStateManager counter to String
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    //When the game is over
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
