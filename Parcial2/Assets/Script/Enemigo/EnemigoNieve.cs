using UnityEngine;

public class EnemigoNieve : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    [SerializeField] private GameObject prefabProyectil; // ¡ACÁ VA LA BOLA DEL ENEMIGO (ProyectilEnemigo)!
    [SerializeField] private Transform puntoDisparo;     
    [SerializeField] private float intervaloDisparo = 2f; 
    [SerializeField] private float rangoVision = 30f;     

    [Header("Referencias")]
    [SerializeField] private Transform jugador; 

    private float proximoDisparo = 0f;

    void Start()
    {
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) jugador = playerObj.transform;
            else Debug.LogError("¡Falta el Tag 'Player' en el XR Origin!");
        }
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoVision)
        {
            if (Time.time >= proximoDisparo)
            {
                Disparar();
                proximoDisparo = Time.time + intervaloDisparo; 
            }
        }
    }

    void Disparar()
    {
        if (prefabProyectil == null || puntoDisparo == null) return;

        // Calculamos dirección a la cámara (ojos del jugador) para que apunte bien
        Transform camara = Camera.main.transform;
        Vector3 direccion = (camara.position - puntoDisparo.position).normalized;

        // Creamos la bola del enemigo
        GameObject bala = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.LookRotation(direccion));
        
        ProyectilEnemigo scriptBala = bala.GetComponent<ProyectilEnemigo>();
        if (scriptBala != null)
        {
            scriptBala.Inicializar(direccion);
        }
    }
}