using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D player;
    private float entradaX;

    public int fuerzaSalto;

    private SpriteRenderer sprite;

    private bool tocandoSuelo;

    public AudioSource sonidoSalto;

    public int puntuacion;

    public TextMeshProUGUI textPuntos;

    public int vidas;
    public TextMeshProUGUI textVidas;


    private bool vulnerable;

    public LifeCounterScript vidasScr;

    public GameObject panelPerder;
    public GameObject panelGanaste;

    public int powerUps;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        velocidad = 10;
        fuerzaSalto = 10;
        sprite = GetComponent<SpriteRenderer>();
        // textVidas.text = vidas.ToString();
        textVidas.text = "";
        vulnerable = true;
        powerUps = CountObjectsWithTag("PowerUp");
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal") +
            joystick.Horizontal;
        if (entradaX < 0)
            sprite.flipX = true;
        if (entradaX > 0) 
            sprite.flipX = false;

        if (Input.GetKeyDown(KeyCode.Space) &&
            tocandoSuelo)
        {
            Saltar();
        }
    }
    private int CountObjectsWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        return objects.Length;
    }
    public void Saltar()
    {
        sonidoSalto.Play();
        player.AddForce(Vector2.up * fuerzaSalto,
            ForceMode2D.Impulse);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemigo" && vulnerable)
        {
            vulnerable = false;
            vidas--;
            vidasScr.gameObject.GetComponent<LifeCounterScript>().ActualizarVidas();
            //textVidas.text = vidas.ToString();
            sprite.color = Color.red;
            Invoke("HacerVulnerable", 4f);
            if (vidas<1)
            {
                sprite.enabled = false;
                panelPerder.SetActive(true);
                Invoke("IrMenu", 4f);
            }
        }
    }

    private void IrMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void HacerVulnerable()
    {
        sprite.color= Color.white;
        vulnerable= true;
        
    }

    public void incrementarPuntos(int cantidad)
    {
        puntuacion = puntuacion + cantidad;
        textPuntos.text =puntuacion.ToString();
        if (--powerUps<1)
        {
            panelGanaste.SetActive(true);
            sprite.enabled= false;
            Invoke("IrMenu", 4f);
        }
    }
}






