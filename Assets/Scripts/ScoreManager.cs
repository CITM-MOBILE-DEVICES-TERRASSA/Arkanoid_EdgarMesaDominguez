using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Instancia única del ScoreManager

    // Campo para la puntuación actual
    private int score = 0;

    // Referencia al objeto de texto en pantalla
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] public TextMeshProUGUI maxScore;

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
        UpdateScoreText();
    }

    // Método para incrementar la puntuación
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Método para actualizar el texto en pantalla
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
