using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rball;
    public float speed = 300;
    public float nudgeForce = 10f; // Fuerza más suave
    public float nudgeVerticalFactor = 0.5f; // Factor para el movimiento vertical del empujón
    private Vector2 velocity;
    Vector2 startingPosition;

    // Audio
    private AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip collisionSound; // Clip de sonido para las colisiones
    

    // Start is called before the first frame update
    void Start()
    {
        rball = GetComponent<Rigidbody2D>(); // Asegúrate de inicializar rball una sola vez aquí
        audioSource = GetComponent<AudioSource>(); // Inicializa el AudioSource
        startingPosition = transform.position;
        ResetBall();
    }

    void Update()
    {
        // Detecta si el jugador presiona la tecla "W"
        if (Input.GetKeyDown(KeyCode.W))
        {
            NudgeBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisión con objetos
        // Reproduce el sonido al colisionar
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound); // Reproduce el sonido de la colisión
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger con otros objetos
    }

    public void ResetBall()
    {
        transform.position = startingPosition; // Vuelve a la posición inicial
        rball.velocity = Vector2.zero; // Reinicia la velocidad
        velocity.x = Random.Range(-1f, 1f); // Genera una dirección aleatoria en X
        velocity.y = 1; // Fuerza siempre hacia arriba en Y
        rball.AddForce(velocity * speed); // Aplica la fuerza inicial
    }

    private void NudgeBall()
    {
        // Aplica un empujón con movimiento lateral y vertical suave
        Vector2 nudgeDirection = new Vector2(Random.Range(-1f, 1f), nudgeVerticalFactor).normalized;
        rball.AddForce(nudgeDirection * nudgeForce, ForceMode2D.Impulse); // Aplica una fuerza instantánea suave
    }
}
