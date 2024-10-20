using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Instancia única del ScoreManager

    // Campo para la puntuación actual
    private int score = 0;
    private int maxScore = 0;

    // Referencia al objeto de texto en pantalla
    [SerializeField] private TextMeshProUGUI scoreText;

    // Referencia al texto que muestra la puntuación máxima
    [SerializeField] private TextMeshProUGUI maxScoreText;

    private void Awake()
    {
        // Configuración del patrón Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicializar el texto de puntuación
        LoadMaxScore();
        UpdateScoreText();
        UpdateMaxScore();
    }

    // Método para incrementar la puntuación
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        if (score > maxScore)
        {
            maxScore = score;
            UpdateMaxScore();
            SaveMaxScore();
        }
    }

    // Método para actualizar el texto en pantalla de la puntuación actual
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Método para actualizar el texto en pantalla de la puntuación máxima
    private void UpdateMaxScore()
    {
        maxScoreText.text = "Max Score: " + maxScore.ToString();
    }

    // Método para guardar la puntuación máxima usando PlayerPrefs
    private void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);
        PlayerPrefs.Save(); // Guardar en disco
    }

    // Método para cargar la puntuación máxima al iniciar el juego
    private void LoadMaxScore()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }
}

