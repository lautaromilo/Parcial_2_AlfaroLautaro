using UnityEngine;

public class BolaDeNieve : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 20f;
    private GameManager gameManager; 

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Destroy(gameObject, tiempoDeVida); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("¡La BolaDeNieve chocó contra: " + collision.gameObject.name + "!");

        EnemigoNieve enemigo = collision.gameObject.GetComponentInParent<EnemigoNieve>();
        
        if (enemigo != null)
        {
            Debug.Log("¡Enemigo detectado! Aplicando daño.");
            enemigo.RecibirDanio(1); 
            Destroy(gameObject); 
        }
    }


    void Update()
    {
        // Si el juego terminó (ganaste o perdiste), la bola se destruye inmediatamente
        if (gameManager != null && gameManager.juegoTerminado)
        {
            Destroy(gameObject);
        }
    }

}

