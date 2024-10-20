using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BrickManager : MonoBehaviour
{
    public static BrickManager instance;
    public GameObject level2;
    public GameObject WinScreen;
    [SerializeField] public TextMeshProUGUI screenText;

    // Número de ladrillos activos
    private int bricksCount;
    public int lastScreen = 0;
    public Ball ballScript;
    

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            Debug.Log("BrickManager instance created");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Contar cuántos ladrillos hay en la escena al inicio
        bricksCount = 30;
        UpdateLastScreenCount();
        Debug.Log("Bricks count: " + bricksCount);
    }

    // Método para disminuir el contador de ladrillos
    public void BrickDestroyed()
    {
        bricksCount--;
        Debug.Log("Bricks destruido, quedan: " + bricksCount);

        // Si ya no quedan ladrillos, cambiar a la siguiente escena
        if (bricksCount <= 0)
        {
            ballScript.ResetBall();
            bricksCount = 30;
            WinScreen.SetActive(true);
            Time.timeScale = 0;
            //LoadNextScene();
        }
    }

    // Método para cargar la siguiente escena
    private void LoadNextScene()
    {
        SceneManager.LoadScene(3); 
    }

    public void LoadLevel2()
    {
        lastScreen = 1;
        level2.SetActive(true);
        WinScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void UpdateLastScreenCount()
    {
        screenText.text = "Last Screen: " + lastScreen;
    }
}
