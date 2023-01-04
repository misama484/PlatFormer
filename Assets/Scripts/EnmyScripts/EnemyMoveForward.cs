using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    //variable publica que determina la velocidad de movimiento del enemigo
    public float speed = 0.5f;
   

    
    void Update()
    {
        //movemos el enemigo hacia la derecha, en el script de changeDirection cambiamos la direccion
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
