using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour   
{
    //declaramos un objeto rigidbody
    Rigidbody2D rb2D;
    //declaramos una variable para la velocidad
    public float runSpeed = 2.2f;
    public float jumpSpeed = 3.0f;
    //accedemos al SpriteRenderer y seleccionamos la propiedad flip, que nos permitira con un bool voltear el sprite para girar
    SpriteRenderer spriteRenderer;
    //animacion de correr, creamos componente animator
    Animator animator;
    //accedemos al audio
    public AudioSource sound;

    void Start()
    {
        //accedendo al componente rigidbody del objeto
        rb2D = GetComponent<Rigidbody2D>();
        //accediendo al componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animacion de correr - accedemos al componente animator
        animator = GetComponent<Animator>();
    }
        
    void Update()
    {
        //capturamos las entradas de teclado
        if (Input.GetKey("d"))
        {
            //movemos el objeto en el eje x
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //volteamos el sprite
            spriteRenderer.flipX = false;
            //accedemos al animator y activamos la animaciond de correr
            animator.SetBool("Run", true);
        }

        else if (Input.GetKey("a"))
        {
            //movemos el objeto en el eje x
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            //volteamos el sprite
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }

        else
        {
            //detenemos el objeto
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            //al parar de moverse, ponemos la animacion en false
            animator.SetBool("Run", false);
        }
        //comprueba que el collider esta tocando "algo" y de ser asi, permite el salto
        if (Input.GetKey("w") && CheckGround.isGrounded) 
        //if (Input.GetKey("w"))
        {
            sound.Play();
            //movemos el objeto en el eje y
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }
       

    }
}
