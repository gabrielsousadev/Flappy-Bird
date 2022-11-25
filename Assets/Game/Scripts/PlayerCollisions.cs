using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.gameObject.CompareTag("Points"))
        {
            gameManager.score++;
            target.GetComponent<AudioSource>().Play();
        }

        if(target.gameObject.CompareTag("Pipes"))
        {
            //gameover
        }
    }
}
