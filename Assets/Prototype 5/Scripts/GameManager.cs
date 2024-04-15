using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //import the libraries of TextMeshPro to interact with TextMeshPro elements
using UnityEngine.SceneManagement; //interact and manage the scenes in scene folder
using UnityEngine.UI; //Interact with UI

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;    //list
    //public GameObject[] targets;  //array
    public TextMeshProUGUI scoreText; //variable that appear in inspector
    public TextMeshProUGUI gameOverText; //variable that appear in inspector
    public Button restartButton; //variable that appear in inspector
    public bool isGameActive;
    public GameObject titleScreen;

    private float spawnRate = 1.0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count); //if List, then use Count. If array, use Length
        Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) //if void, no need return anything. Use public so that it can be used outside of the script
    {  
        score+=scoreToAdd; //equal to score = score + scoreToAdd
        scoreText.text = "Score: " + score;
    }

    public void GameOver() //when game is over, both button and "game over" will show up
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive=false;  //when the game is over, it is not active
    }

    public void RestartGame()
    {
        //reload the scene that currently using
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive=true; //when the game started, it is active
        score=0;
        //------initialize the variable before we start to use them (coroutine)------

        //if easy button, rate is 1/1=1 secs | if medium button, rate is 1/2=0.5 secs
        //smaller the rate, spawn faster
        spawnRate /= difficulty; //equal to spawnRate = spawnRate / difficulty

        StartCoroutine(SpawnTarget()); //must activate the game first, only start the coroutine
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false); //turn off the title screen when the game starts
    }
}
