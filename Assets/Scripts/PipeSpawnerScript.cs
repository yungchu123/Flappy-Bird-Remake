using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else 
        {
            SpawnPipe();
            timer = 0;
        } 
    }

    void SpawnPipe() 
    {
        float verticalDisplacement = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        Instantiate(pipe, transform.position + new Vector3(0, verticalDisplacement, 0), transform.rotation);
    }
}
