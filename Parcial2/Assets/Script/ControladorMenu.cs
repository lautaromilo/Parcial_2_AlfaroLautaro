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
        // Apagamos las particulas al iniciar
        if (particulasNieve != null)
        {
            particulasNieve.Stop();
        }
    }

    public void BotonJugar()
    {
        // Ocultamos el menu y encendemos la nieve
        panelMenuPrincipal.SetActive(false);
        if (particulasNieve != null)
        {
            particulasNieve.Play();
        }
        Debug.Log("¡Se tocó el botón Jugar!");
    }

    public void BotonCreditos()
    {
        // Ocultamos el menu y mostramos los creditos
        panelMenuPrincipal.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void BotonVolverDeCreditos()
    {
        // Ocultamos creditos y volvemos al menu principal
        panelCreditos.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
}