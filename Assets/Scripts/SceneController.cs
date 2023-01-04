using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos libreria textMeshPro
using TMPro;
//importamos libreria unityEngine para acceder a la escena y cambiar de nivel
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //GO de la colecion de frutas en el nivel
    public GameObject fruitsCollection;
    //Contador de frutas
    public static int fruitsRemaining;

    public GameObject end;
    //accedemos a os textMesh del contador de frutas(Canvas)
    public TextMeshProUGUI textFruitsTotal;
    public TextMeshProUGUI textFruitsCollected;
    //accedemos al contador de vidas
    public TextMeshProUGUI lifeCount;
    //accedemos al player para recuperar el scrip respawn y acceder alas vidas
    public GameObject player;

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //accdemos al total de frutas de la FruitsCollection
        fruitsRemaining = fruitsCollection.gameObject.transform.childCount;
        //accedemos a FruitsCollection y mostramos en pantalla el numero de frutas
        
        textFruitsTotal.text = fruitsRemaining.ToString();
        checkFruitsRemaining();
        
        //recuperamos el player y accedemos al script respawn, pasamos las vidas a string y las mostramos en el canvas
        player = GameObject.FindGameObjectWithTag("Player");
        lifeCount.text = player.GetComponent<PlayerRespawn>().health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //lo mismo que en el start y vamos actualizando el contador de vidas
        lifeCount.text = player.GetComponent<PlayerRespawn>().health.ToString();
        scoreText.text = score.ToString();
    }

    //metodo que chekea las frutas recolectadas  las que quedan
    public void checkFruitsRemaining()
    {
        Debug.Log("Quedan " + fruitsRemaining + " frutas");
        textFruitsCollected.text = (int.Parse(textFruitsTotal.text) - fruitsRemaining).ToString();
        
        //si no quedan frutas, activaremos el GO end que nos permite pasar de nivel
        if (fruitsRemaining == 0)
        {
            Debug.Log("Has recogido todas las frutas");
            //cuando no queden frutas, accedemos al gestor de escenas y cambiamos de nivel
            //anyadir escena (abriendo el siguiente nivel en unity) en build settings(add open scene)
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            end.SetActive(true);
            //al activar el GO end, se activa el collider y se ejecuta el metodo OnTriggerEnter2D de EndController
            //que nos permite saltar al siguiente nivel

        }
    }

    
}
