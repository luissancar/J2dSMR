using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public float VelocidaEnX;
    public float VelocidaEnY;

    // Update is called once per frame
    void Update()
    {
        VelocidaEnX = player.GetComponent<Rigidbody2D>().velocity.x;
        VelocidaEnY = player.GetComponent<Rigidbody2D>().velocity.y;
        animator.SetFloat("X", Mathf.Abs(VelocidaEnX));
        animator.SetFloat("Y", Mathf.Abs(VelocidaEnY));
    }
}
