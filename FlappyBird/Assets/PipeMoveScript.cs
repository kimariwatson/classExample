using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedIncreaseRate = 0.2f;
    public float maxSpeed = 15f;
    public float deadZone = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moveSpeed = Mathf.Min(moveSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

        transform.position = transform.position + (Vector3.left * moveSpeed)*Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe is deleted");
            Destroy(gameObject);
        }
    }
}
