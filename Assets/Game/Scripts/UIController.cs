using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameManager gameManager;
    private BirdFly player;
    public GameObject panelStart, panelRestart, panelGame;
    public TMP_Text txtScore, txtFinalScore, txtBestScore;
    public Image[] medals;

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

    public void StartGame()
    {   
        gameManager.StartGame();
        panelStart.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        panelRestart.gameObject.SetActive(false);
        panelStart.gameObject.SetActive(true);
        gameManager.RestartGame();
    }
}
