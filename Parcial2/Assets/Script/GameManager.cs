using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [Header("Interfaz de Usuario (UI)")]
    public GameObject panelPerdiste; 
    public GameObject panelGanaste;  

    // Ahora es pública para que los enemigos sepan que el juego terminó
    public bool juegoTerminado = false; 
    
    private int enemigosRestantes = 0;

    void Start()
    {
        if (panelPerdiste != null) panelPerdiste.SetActive(false);
        if (panelGanaste != null) panelGanaste.SetActive(false);
    }

    public void IniciarConteoEnemigos()
    {
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        Debug.Log("¡El GameManager encontró " + enemigosRestantes + " enemigos en la escena!");
    }

    public void PerderJuego()
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Debug.Log("¡Perdiste!");
        
        if (panelPerdiste != null) 
            panelPerdiste.SetActive(true);
        else 
            Debug.LogError("¡FALTA ASIGNAR EL PANEL PERDISTE EN EL INSPECTOR!");
    }

    public void EnemigoEliminado()
    {
        if (juegoTerminado) return;

        enemigosRestantes--;
        Debug.Log("Enemigos restantes: " + enemigosRestantes);

        if (enemigosRestantes <= 0)
        {
            GanarJuego();
        }
    }

    private void GanarJuego()
    {
        juegoTerminado = true;
        Debug.Log("¡Ganaste!");
        if (panelGanaste != null) 
            panelGanaste.SetActive(true);
        else 
            Debug.LogError("¡FALTA ASIGNAR EL PANEL GANASTE EN EL INSPECTOR!");
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}