using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startGame, gameover;
    public int score;
    public GameObject gameGround;
    private AudioManager audioManager;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void GameOver(GameObject player)
    {
        startGame = false;
        gameover = true;
        gameGround.GetComponent<Animator>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<BirdFly>().rb.bodyType = RigidbodyType2D.Static;
        player.GetComponent<AudioSource>().clip = audioManager.playerAudios[1];
        player.GetComponent<AudioSource>().Play();
    }
}
