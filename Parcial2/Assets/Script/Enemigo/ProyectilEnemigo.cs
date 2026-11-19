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
        transform.position += direccion * velocidad * Time.deltaTime;
    }


  private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            VidaJugador vida = other.GetComponentInParent<VidaJugador>();
            
            if (vida != null)
            {
                vida.RecibirDanio(1); 
            }
            
            Destroy(gameObject); 
            return;
        }

        if (prefabBolaJugador != null)
        {
            Instantiate(prefabBolaJugador, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject); 
    }
}