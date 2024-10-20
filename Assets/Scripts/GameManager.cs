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
   public int lastScreen = 0;
   public int score = 0;
   public GameObject pauseMenu;
   public GameObject map1;
   public GameObject map2;

   public int maxScore = 0;
   
   // Variables para recordar qué mapa estaba activo antes de pausar
    private bool wasMap1Active;
    private bool wasMap2Active;
    
    // Referencia al componente Text del Canvas
   [SerializeField] public TextMeshProUGUI livesText;

   void Awake()
   {
         // Asegúrate de que solo exista una instancia de GameManager
         if (instance == null)
         {
               instance = this;
               //DontDestroyOnLoad(gameObject); // No destruir el objeto al cargar una nueva escena
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
        Time.timeScale = 1; // Asegurarse de que el tiempo no esté pausado al iniciar
        UpdateLivesUI();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0; // Pausa el tiempo del juego

        // Guardar el estado de los mapas antes de pausar
        wasMap1Active = map1.activeSelf;
        wasMap2Active = map2.activeSelf;

        // Desactivar ambos mapas
        map1.SetActive(false);
        map2.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1; // Reanuda el tiempo del juego

        // Restaurar el estado de los mapas al reanudar el juego
        map1.SetActive(wasMap1Active);
        map2.SetActive(wasMap2Active);
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
        livesText.text = "Lives: " + lives;
    }

    public void UpdateMaxScore(){
         if(score > maxScore){
               maxScore = score;
         }
    }

   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si el Canvas (y por tanto livesText) es diferente en cada escena, reasignamos el TextMeshProUGUI
        //livesText = FindObjectOfType<TextMeshProUGUI>();

        // Volvemos a actualizar las vidas en la nueva escena
        UpdateLivesUI();
    }
}