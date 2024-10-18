using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPala : MonoBehaviour
{
    public float speed = 10f; 
    public float maxX = 7.5f;
    public float minX = -7.5f;
    float horizontalMovement;
    Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if ((horizontalMovement > 0 && transform.position.x < maxX) || (horizontalMovement < 0 && transform.position.x > minX))
        {
            transform.position += Vector3.right * horizontalMovement * Time.deltaTime * speed;
        }
    }

    public void ResetPlayer(){
        transform.position = startingPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}