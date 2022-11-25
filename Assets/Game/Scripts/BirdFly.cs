using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float velocity;
    [HideInInspector] public Rigidbody2D rb;
    private GameManager gameManager;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FlyTheBird();
    }

    public void FlyTheBird()
    {
        if (Input.GetMouseButtonDown(0) && !gameManager.gameover)
        {
            gameObject.GetComponent<AudioSource>().clip = audioManager.playerAudios[0];
            gameObject.GetComponent<AudioSource>().Play();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * velocity;
        }
    }

    public IEnumerator BirdGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<AudioSource>().clip = audioManager.playerAudios[2];
        gameObject.GetComponent<AudioSource>().Play();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = Vector2.zero;
    }
}
