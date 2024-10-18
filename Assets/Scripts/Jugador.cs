using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Rigidbody2D rb;  
    private float inputValue;
    public float speed = 25;
    private Vector2 direction;

    void Update()
    {
        inputValue = Input.GetAxis("Horizontal");

        if (inputValue == 1){
            direction = Vector2.right;
        }
        else if (inputValue == -1){
            direction = Vector2.left;
     
       }
       else{
            direction = Vector2.zero;
       }

       rb.AddForce(direction * speed * Time.deltaTime * 100);
    }
}
