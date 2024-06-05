using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DificultiMenu : MonoBehaviour
{

    public GameObject difficultyPanel;
    public Text difficultyText;

    private DobleCirculListed listaDificultades;

    private void Awake()
    {
        listaDificultades = new DobleCirculListed();
        listaDificultades.Añadir("Fácil");
        listaDificultades.Añadir("Normal");
        listaDificultades.Añadir("Difícil");

        ActualizarTextoDificultad();
    }

    public void AbrirPanel()
    {
        difficultyPanel.SetActive(true);
        ActualizarTextoDificultad();
    }

    public void CerrarPanel()
    {
        difficultyPanel.SetActive(false);
    }

    public void SiguienteDificultad()
    {
        listaDificultades.Siguiente();
        ActualizarTextoDificultad();
    }

    public void AnteriorDificultad()
    {
        listaDificultades.Anterior();
        ActualizarTextoDificultad();
    }

    public void ConfirmarDificultad()
    {
        string dificultadSeleccionada = listaDificultades.ObtenerValorActual();
        Debug.Log("Dificultad seleccionada: " + dificultadSeleccionada);

        
        switch (dificultadSeleccionada)
        {
            case "Fácil":
                SceneManager.LoadScene("EasyScene");
                break;
            case "Normal":
                SceneManager.LoadScene("NormalScene");
                break;
            case "Difícil":
                SceneManager.LoadScene("HardScene");
                break;
            default:
                Debug.LogError("Dificultad no válida seleccionada.");
                break;
        }
    }

    private void ActualizarTextoDificultad()
    {
        difficultyText.text = listaDificultades.ObtenerValorActual();
    }

}
