using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D player;
    private float entradaX;

    public int fuerzaSalto;

    private SpriteRenderer sprite;

    private bool tocandoSuelo;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        velocidad = 10;
        fuerzaSalto = 10;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");
        if (entradaX < 0)
            sprite.flipX = true;
        if (entradaX > 0) 
            sprite.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) &&
            tocandoSuelo)
        {
            player.AddForce(Vector2.up * fuerzaSalto,
                ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        player.velocity = new Vector2(entradaX * velocidad,
             player.velocity.y);
    }
    /*
    bool TocandoSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(
            transform.position + new Vector3(0,-2f, 0),
            Vector2.down,0.2f);
        return toca.collider != null;
    }
    */

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
            tocandoSuelo = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        tocandoSuelo = false;
    }
}
