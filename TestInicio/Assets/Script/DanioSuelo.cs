using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioSuelo : MonoBehaviour
{

    [SerializeField] PlayerHealth pHealth;
    int danioSuelo;
    // Start is called before the first frame update
    void Start()
    {
        danioSuelo = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pHealth.danioPersonaje(danioSuelo);
        }
    }
}

