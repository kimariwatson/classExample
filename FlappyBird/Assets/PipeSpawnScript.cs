using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    //public GameObject player1;
    //public GameObject player2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;

    public GameObject pipe;
    public float SpawnRate = 2f;
    private float timer = 0;
    public float heightOffset = 1;
    // Start is called before the first frame update
    void Start()
    {
        //rb1 = player1.GetComponent<Rigidbody2D>();
        //rb2 = player2.GetComponent<Rigidbody2D>();

        rb1 = GameObject.Find("Player 1").GetComponent<Rigidbody2D>();
        rb2 = GameObject.Find("Player 2").GetComponent<Rigidbody2D>();

        //SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb1.simulated == true || rb2.simulated == true)
        {
            if (timer < SpawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
                //Instantiate(pipe, transform.position, transform.rotation);
            }
        }
    }
    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
