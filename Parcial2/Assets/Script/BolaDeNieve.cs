using UnityEngine;

public class BolaJugador : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 30f; // Se destruye a los 30 seg para no llenar la escena

    void Start()
    {
        Destroy(gameObject, tiempoDeVida); 
    }

    // (Opcional para el próximo Sprint) Aquí iría el código para hacerle daño al muñeco
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            // EnemigoNieve enemigo = collision.gameObject.GetComponent<EnemigoNieve>();
            // if (enemigo != null) enemigo.RecibirDanio();
            Destroy(gameObject);
        }
    }
}