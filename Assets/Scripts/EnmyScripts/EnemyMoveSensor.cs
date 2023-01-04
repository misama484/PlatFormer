using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSensor : MonoBehaviour
{
    //variable publica que determina la velocidad de movimiento del enemigo
    public float speed = 5f;
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cuando el player entra en contacto con el collider,duplicamos la velocidad
        if (collision.transform.CompareTag("Player"))
        {
            //movemos el enemigo hacia la derecha, en el script de changeDirection cambiamos la direccion
            //enemy.transform.position += Vector3.left * speed * Time.deltaTime;
            enemy.GetComponent<EnemyMoveForward>().speed = speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //cuando el player sale del collider, volvemos a la velocidad normal
        if (collision.transform.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyMoveForward>().speed = 0.5f;
        }
    }

}
