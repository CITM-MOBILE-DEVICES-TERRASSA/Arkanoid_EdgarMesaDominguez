using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("Collision");
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball hit DeadZone");
            FindObjectOfType<GameManager>().loseHealth();
        }
    }

    

}
