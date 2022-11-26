using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Points") && !gameManager.gameover)
        {
            gameManager.score++;
            uiController.txtScore.text = gameManager.score.ToString();
            target.GetComponent<AudioSource>().Play();
        }

        if (target.gameObject.CompareTag("Pipe") && !gameManager.gameover)
        {
            gameManager.GameOver(this.gameObject);
            StartCoroutine(gameObject.GetComponent<BirdFly>().BirdGameOver());
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground") && !gameManager.gameover)
        {
            gameManager.GameOver(this.gameObject);
            StartCoroutine(gameObject.GetComponent<BirdFly>().BirdGameOver());
        }
    }
}
