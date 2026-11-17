using UnityEngine;

public class EnemigoNieve : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    [SerializeField] private GameObject prefabProyectil; 
    [SerializeField] private Transform puntoDisparo;     
    [SerializeField] private float intervaloDisparo = 2f; 
    [SerializeField] private float rangoVision = 30f;     

    [Header("Referencias")]
    [SerializeField] private Transform jugador; 

    [Header("Vida")]
    [SerializeField] private int vidas = 2; 

    private float proximoDisparo = 0f;

    void Start()
    {
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) jugador = playerObj.transform;
        }
    }

    void Update()
    {
        if (jugador == null || vidas <= 0) return; // Si está muerto o jugador perdió, no hace nada

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

        Transform camara = Camera.main.transform;
        Vector3 direccion = (camara.position - puntoDisparo.position).normalized;

        GameObject bala = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.LookRotation(direccion));
        
        ProyectilEnemigo scriptBala = bala.GetComponent<ProyectilEnemigo>();
        if (scriptBala != null)
        {
            scriptBala.Inicializar(direccion);
        }
    }

    public void RecibirDanio(int cantidad)
    {
        vidas -= cantidad;
        Debug.Log(gameObject.name + " recibió daño. Vidas restantes: " + vidas);
        Debug.Log("le pegue");

        if (vidas <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Debug.Log(gameObject.name + " ha sido eliminado.");
        
        Destroy(gameObject); 
    }
}