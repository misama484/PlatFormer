using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Maneja el movimiento aleatorio de la abeja mediante un array de posiciones
    public Transform[] moveSpots;

    public float speed = 0.5f;
    int i = 0;


    // Update is called once per frame
    void Update()
    {
        //MoveTowards interpola valores de posicion del GO entre 2 puntos, cada speed actualiza valor
        //Distance calcula la distancia entre 2 puntos, devuelve la magnitud del vector resultante(float)
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
            
        }
    }
}
