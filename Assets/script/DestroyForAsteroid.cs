using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForAsteroid : MonoBehaviour
{
    public GameObject boom;
    public GameObject playerBoom;

    Rigidbody rb;
    float speed;

    ForGame game;

    
    
    void Start()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<ForGame>();
        rb = GetComponent<Rigidbody>();
        
    }
    


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "laserdestroy")
        {
            return;
        }

        Instantiate(boom, transform.position, transform.rotation);

        

        if (other.tag == "Player")
        {
            Instantiate(playerBoom, other.transform.position, other.transform.rotation); 
            game.GameOver();
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
        game.UpdatePoint();
        
    }
    

}
