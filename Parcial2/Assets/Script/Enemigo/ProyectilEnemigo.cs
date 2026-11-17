using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    [SerializeField] private float velocidad = 12f;
    [SerializeField] private GameObject prefabBolaJugador; // La bola que SÍ se puede agarrar
    [SerializeField] private float tiempoDeVida = 5f; 

    private Vector3 direccion;

    public void Inicializar(Vector3 dir)
    {
        direccion = dir.normalized;
        Destroy(gameObject, tiempoDeVida); 
    }

    void Update()
    {
        // Se mueve constantemente hacia adelante
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si te pega a vos, por ahora desaparece
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }

        // Si choca contra el piso o una pared, se convierte en la bola agarrable
        if (prefabBolaJugador != null)
        {
            Instantiate(prefabBolaJugador, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject); // Destruye la bola "fantasma" del enemigo
    }
}