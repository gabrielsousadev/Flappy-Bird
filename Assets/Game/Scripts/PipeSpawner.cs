using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1, timer = 0, height;
    [SerializeField] private GameObject pipePrefab;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newPipe = Instantiate(pipePrefab);
        newPipe.transform.position = (Vector2)transform.position + new Vector2(0f, Random.Range(-height, height));
        Destroy(newPipe, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipePrefab);
            newPipe.transform.position = (Vector2)transform.position + new Vector2(0f, Random.Range(-height, height));
            Destroy(newPipe, 10);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
