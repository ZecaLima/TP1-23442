using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // verificar se o objeto que colidiu é o jogador
        if(other.gameObject.name != "Player")
        {
            return;
        }

        // aumentar a pontuação
        GameManager.instance.IncrementScore();

        //destroi a moeda
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
