using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{

    [SerializeField] PlayerHealth pHealth;
    int danioAtaque;
    // Start is called before the first frame update
    void Start()
    {
        danioAtaque = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
            pHealth.danioPersonaje(danioAtaque);
            }
    }
}
