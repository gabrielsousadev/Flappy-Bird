using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SetData(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public int GetData()
    {
        int bestScore = PlayerPrefs.GetInt("score");
        return bestScore;
    }
}
