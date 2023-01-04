using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    //detectamos el valor que retorna al mover joystick
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    //declaramos el joystick
    public Joystick joystick;


    //declaramos un objeto rigidbody
    Rigidbody2D rb2D;
    //declaramos una variable para la velocidad
    public float runSpeed = 1.2f;
    public float jumpSpeed = 4.0f;
    //joystic
    public float runSpeedHorizontal = 2.2f;
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
        //capturamos el valor del joystick
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;        
        
        //movemos el objeto en el eje x
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
        
        //capturamos el moimiento del joystick
        if (horizontalMove > 0)
        {
            
            //volteamos el sprite
            spriteRenderer.flipX = false;
            //accedemos al animator y activamos la animaciond de correr
            animator.SetBool("Run", true);
        }

        else if (horizontalMove < 0)
        {
            //volteamos el sprite
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }

        else
        {
            //al parar de moverse, ponemos la animacion en false
            animator.SetBool("Run", false);
        }

        //animations 
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }


    }
    

    public void Jump()
    {
        //comprueba que el collider esta tocando "algo" y de ser asi, permite el salto
        if (CheckGround.isGrounded)
        {

            sound.Play();
            //movemos el objeto en el eje y
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);


        }
    }
}
