using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class GameManager : MonoBehaviour
{
    [Header("Interfaz de Usuario (UI)")]
    public GameObject panelPerdiste; 
    public GameObject panelGanaste;  

    [Header("Configuración de Vida")]
    public int vidaMaxima = 3;
    private int vidaActual;
    
    
    private bool juegoTerminado = false;

    void Start()
    {
        
        if (panelPerdiste != null) panelPerdiste.SetActive(false);
        if (panelGanaste != null) panelGanaste.SetActive(false);
        
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int cantidad)
    {
        if (juegoTerminado) return; 

        vidaActual -= cantidad;
        Debug.Log("Vida actual: " + vidaActual);

        if (vidaActual <= 0)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        Debug.Log("¡Ganaste!");
        
        if (panelGanaste != null) panelGanaste.SetActive(true);
    }

    private void PerderJuego()
    {
        juegoTerminado = true;
        Debug.Log("¡Perdiste!");
        
        if (panelPerdiste != null) panelPerdiste.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}