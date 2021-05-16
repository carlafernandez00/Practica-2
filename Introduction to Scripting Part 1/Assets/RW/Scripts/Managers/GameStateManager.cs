using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; //save the instance of the script itself

    [HideInInspector]         // editor won't see the variable it's assigned
    public int sheepSaved;    // Amount of sheep that hasn't been hit

    [HideInInspector] 
    public int sheepDropped;  // Num of sheep that drop

    public int sheepDroppedBeforeGameOver; // Sheep that are allowed to drop before the game ends
    public SheepSpawner sheepSpawner;      // reference to the SheepSpawner


    // Awake is the first to be called (it's used to set references)
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // when escape is press, SceneManager loads the title screen scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    // Increment the score everytime a sheep has been saved
    public void SavedSheep()
    {
        sheepSaved++;
        //update the text
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false;  //Do not create more sheep
        sheepSpawner.DestroyAllSheep(); //Destroy all sheep using a sheepSpawner method
        //update the text
        UIManager.Instance.ShowGameOverWindow();
    }

    // Called everytime a sheep falls down
    public void DroppedSheep()
    {
        sheepDropped++;                           //increment the counter
        UIManager.Instance.UpdateSheepDropped();  //update the text

        //if the counter if equal to the amount allowed
        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
}
