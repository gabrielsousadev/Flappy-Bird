using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startGame, gameover;
    public int score;
    public GameObject gameGround;
    private AudioManager audioManager;
    public BirdFly player;
    private PipeSpawner pipeSpawner;
    private UIController uiController;
    private SaveController saveController;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        player = FindObjectOfType<BirdFly>();
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        uiController = FindObjectOfType<UIController>();
        saveController = FindObjectOfType<SaveController>();
    }

    public void GameOver(GameObject player)
    {
        SaveScore();
        uiController.panelRestart.gameObject.SetActive(true);
        uiController.panelGame.gameObject.SetActive(false);
        startGame = false;
        gameover = true;
        gameGround.GetComponent<Animator>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<BirdFly>().rb.bodyType = RigidbodyType2D.Static;
        player.GetComponent<AudioSource>().clip = audioManager.playerAudios[1];
        player.GetComponent<AudioSource>().Play();
        uiController.txtFinalScore.text = score.ToString();
        Medals();
        uiController.txtBestScore.text = saveController.GetData().ToString();
    }

    public void StartGame()
    {
        startGame = true;
        gameover = false;
        player.FlyTheBird();
    }

    public void RestartGame()
    {
        gameover = false;
        gameGround.GetComponent<Animator>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<BirdFly>().rb.bodyType = RigidbodyType2D.Static;
        player.GetComponent<AudioSource>().clip = audioManager.playerAudios[0];
        player.transform.position = new Vector2(-0.5f, 0f);
        score = 0;
        uiController.txtScore.text = score.ToString();
        DestroyAllPipes();
    }

    private void DestroyAllPipes()
    {
        foreach (Transform pipe in pipeSpawner.transform)
        {
            Destroy(pipe.gameObject);
        }
    }

    private void Medals()
    {
        if(score <= 10)
        {
            uiController.medals[0].gameObject.SetActive(true);
            uiController.medals[1].gameObject.SetActive(false);
        }

        else if(score > 10)
        {
            uiController.medals[0].gameObject.SetActive(false);
            uiController.medals[1].gameObject.SetActive(true);
        }
    }

    public void SaveScore()
    {
        int bestScore = saveController.GetData();

        if(score > bestScore)
        {
            saveController.SetData(score);
        }

        Debug.Log(saveController.GetData());
    }
}
