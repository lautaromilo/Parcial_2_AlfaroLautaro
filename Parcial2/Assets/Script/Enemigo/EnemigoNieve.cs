using UnityEngine;

public class EnemigoNieve : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    [SerializeField] private GameObject prefabProyectil; // La bola de nieve
    [SerializeField] private Transform puntoDisparo;     // El lugar en la mano
    [SerializeField] private float intervaloDisparo = 2f; // Cada cuánto dispara
    [SerializeField] private float rangoVision = 30f;     // Distancia para verte

    [Header("Referencias")]
    [SerializeField] private Transform jugador; // El XR Origin

    private float proximoDisparo = 0f;

    void Start()
    {
        // Si no lo asignamos en el Inspector, lo busca por el Tag
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) jugador = playerObj.transform;
        }
    }

    void Update()
    {
        if (jugador == null) return;

        // 1. Comprobar si el jugador está en rango
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoVision)
        {
            // 2. Comprobar si ya pasó el tiempo
            if (Time.time >= proximoDisparo)
            {
                Disparar();
                proximoDisparo = Time.time + intervaloDisparo; // Reinicia el temporizador
            }
        }
    }

    void Disparar()
    {
        if (prefabProyectil == null || puntoDisparo == null) return;

        // Calcular la dirección desde la mano hasta el jugador
        Vector3 direccion = (jugador.position - puntoDisparo.position).normalized;

        // Instanciar la bala en la mano, mirando hacia el jugador
        GameObject bala = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.LookRotation(direccion));
        
        // Pasarle la dirección a la bala para que se mueva
        ProyectilEnemigo scriptBala = bala.GetComponent<ProyectilEnemigo>();
        if (scriptBala != null)
        {
            scriptBala.Inicializar(direccion);
        }
    }
}