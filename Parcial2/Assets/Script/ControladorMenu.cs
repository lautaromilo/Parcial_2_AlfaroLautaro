using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    [Header("Paneles de UI")]
    [SerializeField] private GameObject panelMenuPrincipal;
    [SerializeField] private GameObject panelCreditos;

    [Header("Elementos del Escenario")]
    [SerializeField] private ParticleSystem particulasNieve; 

    void Start()
    {
        if (particulasNieve != null)
        {
            particulasNieve.Stop();
        }
    }

    public void BotonJugar()
    {
        panelMenuPrincipal.SetActive(false);
        
        if (particulasNieve != null)
        {
            particulasNieve.Play();
        }

        EnemigoNieve[] enemigos = FindObjectsByType<EnemigoNieve>(FindObjectsSortMode.None);
        foreach (EnemigoNieve enemigo in enemigos)
        {
            enemigo.juegoIniciado = true;
        }

        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null)
        {
            gm.IniciarConteoEnemigos();
        }

        Debug.Log("¡Se tocó el botón Jugar!");
    }

    public void BotonCreditos()
    {
        panelMenuPrincipal.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void BotonVolverDeCreditos()
    {
        panelCreditos.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
}