using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float efectoParallax;
    private Transform camara;
    private Vector3 ultimaPosicionCamara;

    void Start()
    {
        camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimientoFondo = camara.position 
            - ultimaPosicionCamara;
        transform.position += new Vector3(
            movimientoFondo.x * efectoParallax,
            movimientoFondo.y, 0);
        ultimaPosicionCamara= camara.position;
        
    }
}
