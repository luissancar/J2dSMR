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
        // Actualiza la posici�n del objeto de texto en funci�n de la posici�n del jugador
        texto.transform.position = Camera.main.WorldToScreenPoint(jugador.position);
    }
}


