using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //import library, to interact with Button

public class DifficultyButton : MonoBehaviour
{
    private Button button; //create reference for button
    private GameManager gameManager; //create reference 

    public int difficulty; //in inspector, assign different values (1,2,3) to the easy/medium/hard buttons

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); //get the actual button component on our button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //"Game Manager" is the name of the game object
        
        button.onClick.AddListener(SetDifficulty); //AddListener()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame(difficulty); //method from GameManager script
    }
}
