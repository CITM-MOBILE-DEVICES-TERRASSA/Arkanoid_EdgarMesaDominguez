using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLives : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("Lives"))
        {
            GameManager.instance.lives = PlayerPrefs.GetInt("Lives");
        }
    }
}
