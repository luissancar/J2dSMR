using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public GameObject panel;



    private void Start()
    {
        panel.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void SalirCreditos()
    {
        panel.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Creditos()
    {
        panel.SetActive(true);
    }
}
