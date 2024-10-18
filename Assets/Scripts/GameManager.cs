using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   //instance 
   public static GameManager instance;
   public int lives = 3;
   public int score = 0;
    
    // Referencia al componente Text del Canvas
   [SerializeField] public TextMeshProUGUI livesText;

   void Awake()
   {
         // Asegúrate de que solo exista una instancia de GameManager
         if (instance == null)
         {
               instance = this;
               DontDestroyOnLoad(gameObject); // Mantiene este objeto al cambiar de escena
         }
         else if (instance != this)
         {
               Destroy(gameObject); // Si ya existe una instancia, destruye esta para evitar duplicados
         }
   }
   void OnEnable()
    {
        // Suscribirse al evento cuando una escena haya sido cargada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Desuscribirse del evento cuando el objeto se desactiva o destruye
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // Inicializamos el texto al comienzo
        UpdateLivesUI();
    }

    public void loseHealth()
    {
        lives--;
        UpdateLivesUI();  // Actualizamos la UI cada vez que cambia el valor de las vidas

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<PruebaPala>().ResetPlayer();
    }

    // Método para actualizar el texto de las vidas
    public void UpdateLivesUI()
    {
        PlayerPrefs.SetInt("Lives", lives);
        livesText.text = "Lives: " + lives;
    }

   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si el Canvas (y por tanto livesText) es diferente en cada escena, reasignamos el TextMeshProUGUI
        livesText = FindObjectOfType<TextMeshProUGUI>();

        // Volvemos a actualizar las vidas en la nueva escena
        UpdateLivesUI();
    }
}