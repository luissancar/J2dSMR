
//  https://github.com/luissancar/J2dSMR


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public int velocidad;
    public Vector3 posicionInicio;
    public Vector3 posicionFinal;
    private bool moviendoAFin;

    public int topeX;
    public int topeY;


    private SpriteRenderer sprite;

    public GameObject player;



    void Start()
    {
        posicionInicio = transform.position;
        posicionFinal = new Vector3(posicionInicio.x + topeX,
            posicionInicio.y + topeY, posicionInicio.z);
        moviendoAFin = true;
        sprite = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
        VerPlayer();
    }

    private void VerPlayer()
    {
        if (player == null)
            return;
        if (player.transform.position.x 
            < transform.position.x)
            sprite.flipX = false;
        else
            sprite.flipX = true;
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





