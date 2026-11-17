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
        // Si le pega al jugador
        if (other.CompareTag("Player"))
        {
            // Buscamos el script VidaJugador
            VidaJugador vida = other.GetComponentInParent<VidaJugador>();
            
            if (vida != null)
            {
                vida.RecibirDanio(1); // Le saca 1 de vida
            }
            
            Destroy(gameObject); // La bola del enemigo desaparece
            return;
        }

        // Si choca contra el piso o pared, se convierte en bola agarrable
        if (prefabBolaJugador != null)
        {
            Instantiate(prefabBolaJugador, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject); 
    }
}