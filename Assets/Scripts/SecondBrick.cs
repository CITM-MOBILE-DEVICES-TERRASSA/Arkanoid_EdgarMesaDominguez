using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondBrick : MonoBehaviour
{
   // Número de golpes que puede recibir el ladrillo
    [SerializeField] private int hitPoints = 1;

    // Materiales o colores para indicar el estado del ladrillo
    [SerializeField] private Sprite[] damageSprites;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private int points = 100; // Puntos que se suman al destruir el ladrillo


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Reducir los puntos de vida
            hitPoints--;

            // Actualizar la apariencia del ladrillo según los puntos de vida
            UpdateBrickAppearance();

            // Si los puntos de vida llegan a 0, destruir el ladrillo
            if (hitPoints <= 0)
            {
                BrickManager.instance.BrickDestroyed();
                ScoreManager.instance.AddScore(points);
                Destroy(gameObject);
            }
        }
    }

    // Método para actualizar la apariencia del ladrillo
    private void UpdateBrickAppearance()
    {
        if (damageSprites != null && damageSprites.Length > 0)
        {
            int spriteIndex = Mathf.Clamp(damageSprites.Length - hitPoints, 0, damageSprites.Length - 1);
            spriteRenderer.sprite = damageSprites[spriteIndex];
        }
    }
}
