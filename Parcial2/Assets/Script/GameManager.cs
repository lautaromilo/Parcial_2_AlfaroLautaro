using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [Header("Interfaz de Usuario (UI)")]
    public GameObject panelPerdiste; 
    public GameObject panelGanaste;  

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
            Debug.LogError("Nooo");
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
            Debug.LogError("Nooox2");
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}