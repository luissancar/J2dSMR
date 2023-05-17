using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeCounterScript : MonoBehaviour
{
    public Image[] spritesVidas;
    public int vidasRestantes;
    private void Start()
    {
        vidasRestantes = spritesVidas.Length - 1;
    }

    public void ActualizarVidas()
    {

        spritesVidas[vidasRestantes--].gameObject.SetActive(false);
        /*
        for (int i = 0; i < spritesVidas.Length; i++)
        {
            if (i < vidasRestantes)
            {
                spritesVidas[i].gameObject.SetActive(true);
            }
            else
            {
                spritesVidas[i].gameObject.SetActive(false);
            }
        }*/
    }
}
