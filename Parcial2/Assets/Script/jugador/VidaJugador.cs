using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    [Header("Vida del Jugador")]
    [SerializeField] private int vidaMaxima = 10;
    private int vidaActual;
    
    private GameManager gameManager;

    void Start()
    {
        vidaActual = vidaMaxima;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("¡Jugador golpeado! Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            if (gameManager != null)
            {
                gameManager.PerderJuego();
            }
        }
    }
}