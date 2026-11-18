using UnityEngine;

public class BolaDeNieve : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 30f; 

    void Start()
    {
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
}