using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public static bool isGrounded;

    //comprueba si esta tocando suelo y cambia el valor de la variable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //esta en el suelo
        isGrounded = true;
        //Debug.Log("ESTA EN EL SUELO");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //esta en el aire
        isGrounded = false;
        //Debug.Log("ESTA EN EL AIRE");
    }
}
