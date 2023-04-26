using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject enemigo;
    public int velocidad;
    public Vector3 posicionInicio;
    public Vector3 posicionFinal;
    private bool moviendoAFin;

    public int topeX;
    public int topeY;



    void Start()
    {
        posicionInicio = transform.position;
        posicionFinal = new Vector3(posicionInicio.x + topeX,
            posicionInicio.y + topeY, posicionInicio.z);
        moviendoAFin = true;
        velocidad = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (moviendoAFin) ?
            posicionFinal : posicionInicio;
        transform.position = Vector3.MoveTowards(transform.position,
            posicionDestino, velocidad * Time.deltaTime);
        if (transform.position == posicionFinal) 
        {
            moviendoAFin=false;
        }
        if (transform.position == posicionInicio)
        {
            moviendoAFin = true;
        }
    }
}





