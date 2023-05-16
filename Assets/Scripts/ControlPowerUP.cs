using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUP : MonoBehaviour
{
    public int cantidad;
    public AudioSource sonido;
    private bool entrado;

    void start()
    {
        entrado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !entrado)
        {
            entrado=true;
            sonido.Play();
            collision.gameObject.GetComponent<PlayerController>().
                incrementarPuntos(cantidad);
            GetComponent<TextoPosicion>().activo = true;
            Destroy(gameObject,1);    

        }
    }
}
