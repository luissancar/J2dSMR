using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPosicion : MonoBehaviour
{
    public GameObject objetoDondeMostrar;
    public TextMeshProUGUI textoCanvas;
    public int sumaY, sumaX;
    public bool activo;
    public string textoAMostrar;


    private void Start()
    {
        textoCanvas.text = "";
        activo = false;
    }

    private void Update()
    {
        if (activo)
        {
            textoCanvas.text = textoAMostrar;
            Vector3 posicionObjeto;
            posicionObjeto = Camera.main.WorldToScreenPoint(
                objetoDondeMostrar.transform.position );
            textoCanvas.transform.position = new Vector3(
                posicionObjeto.x + sumaX, posicionObjeto.y + sumaY,
                posicionObjeto.z );

        }
    }

    private void OnDestroy()
    {
        textoCanvas.text = "";
    }


}


