using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button btnStart;
    private GameManager gameManager;
    private BirdFly player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<BirdFly>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnStartGame()
    {   
        player.FlyTheBird();
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.up * player.velocity;
        gameManager.startGame = true;
        btnStart.gameObject.SetActive(false);
    }
}
