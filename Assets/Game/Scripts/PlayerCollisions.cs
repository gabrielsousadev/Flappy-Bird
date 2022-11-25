using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Points"))
        {
            gameManager.score++;
            target.GetComponent<AudioSource>().Play();
        }

        if (target.gameObject.CompareTag("Pipe") && !gameManager.gameover)
        {
            gameManager.startGame = false;
            gameManager.gameover = true;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<BirdFly>().rb.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<AudioSource>().clip = audioManager.playerAudios[1];
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(gameObject.GetComponent<BirdFly>().BirdGameOver());
        }
    }
}
