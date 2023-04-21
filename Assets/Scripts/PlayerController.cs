using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D player;
    private float entradaX;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        velocidad = 10;
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        player.velocity = new Vector2(entradaX * velocidad,
             player.velocity.y);
    }
}
