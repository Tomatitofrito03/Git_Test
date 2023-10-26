using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private int vida;
    [SerializeField] private int vidaMaxima;

    public RespawnPoint respawnPoint;
    public BarraDeVida UIBarraVida;
    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMaxima;
        UIBarraVida.SetVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void danioPersonaje(int danioCantidad)
    {
        vida -= danioCantidad;
        UIBarraVida.SetVida(vida);

        if (vida <= 0)
        {
            //Destroy(gameObject);
            Respawn();
        }
        Debug.Log(vida);
    }
    
    private void Respawn()
    {
        Transform nuevoTransform = respawnPoint.getLastRespawnPoint();  
        transform.position = nuevoTransform.position;
        if (vida <= 0)
        {
            vida = vidaMaxima;
            UIBarraVida.SetVida(vida);
        }
        //transform.position = respawnPoint.getLastRespawnPoint().position;
    }
}
