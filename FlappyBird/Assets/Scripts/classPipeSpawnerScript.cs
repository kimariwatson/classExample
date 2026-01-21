using UnityEngine;

public class classPipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    public float timer = 0f;
    public float heightOffset = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timer = spawnRate;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spawnRate)
        {
            //timer = timer + Time.deltaTime;
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }
    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}
