using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; 
// NOTA: Si te da error esta línea, probá borrando ".Interactables" y dejando solo "using UnityEngine.XR.Interaction.Toolkit;"

public class ProyectilEnemigo : MonoBehaviour
{
    [Header("Configuración de la Bala")]
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private float tiempoDeVida = 25f; 

    private Vector3 direccion;
    private bool enVuelo = true;

    // Componentes que vamos a controlar
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        // Obtenemos los componentes del objeto
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Al nacer (mientras vuela), no se puede agarrar y no le afecta la gravedad
        if (grabInteractable != null) grabInteractable.enabled = false;
        
        if (rb != null) 
        {
            rb.isKinematic = true; 
            rb.useGravity = false; // Desactivamos la gravedad mientras vuela
        }
        
        // Nos aseguramos de que sea un trigger para no chocar físicamente mientras vuela
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true; 
    }

    // Esta función es llamada por el Enemigo justo después de crearlo
    public void Inicializar(Vector3 dir)
    {
        direccion = dir.normalized;
        Destroy(gameObject, tiempoDeVida); // Se autodestruye para no llenar la escena
    }

    void Update()
    {
        // Solo se mueve por código mientras está en vuelo
        if (enVuelo)
        {
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!enVuelo) return; // Si ya está en el piso, ignoramos las colisiones

        // Si le pega al jugador (por ahora lo destruimos, en el futuro le quitaremos vida)
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
        else 
        {
            // 1. Deja de volar
            enVuelo = false; 
            
            // 2. Le devolvemos la física (gravedad) para que caiga al piso
            if (rb != null) 
            {
                rb.isKinematic = false;
                rb.useGravity = true; 
            }
            
            // 3. Permitimos que el jugador la pueda agarrar con VR
            if (grabInteractable != null) grabInteractable.enabled = true;
            
            // NOTA: Ya NO cambiamos el isTrigger a false. Eso era lo que hacía que 
            // Unity empuje la bola hacia arriba y parezca que levita.
        }
    }
}