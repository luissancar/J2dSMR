using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoPosicion : MonoBehaviour
{
  
    public Transform jugador;
    public UnityEngine.UI.Text texto;

    void Update()
    {
        texto.text = "dddd";
        // Actualiza la posición del objeto de texto en función de la posición del jugador
        texto.transform.position = Camera.main.WorldToScreenPoint(jugador.position);
    }
}


