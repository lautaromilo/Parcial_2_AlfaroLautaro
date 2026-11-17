using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    [Header("Vida del Jugador")]
    [SerializeField] private int vidaMaxima = 10; // Poné 10 en el Inspector
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("¡Jugador golpeado! Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            Debug.Log("¡Has muerto! (Por ahora solo es un mensaje)");
        }
    }
}