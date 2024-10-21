using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
       //cambiar a la escena principal
        SceneManager.LoadScene(0);
    }
    public void SaveGame()
    {
        //guardar la partida
        PlayerPrefs.SetInt("Lives", GameManager.instance.lives);
        PlayerPrefs.SetInt("Score", ScoreManager.instance.score);
        PlayerPrefs.Save(); // Asegurarse de que se guarden los datos
        Debug.Log("Game saved!");
        SceneManager.LoadScene(0);

    }
}
