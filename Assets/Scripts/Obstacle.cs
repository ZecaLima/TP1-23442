using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar se o objeto que colidiu é o player
        if(collision.gameObject.name == "Player")
        {
            // Kill Player
            playerMovement.Die();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
