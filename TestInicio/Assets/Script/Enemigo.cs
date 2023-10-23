using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform PointA; //los puntos en el mapa hasta los que se mueve mi personaje y luego gira
    [SerializeField] Transform PointB;

    bool estaMirandoDerecha;
    [SerializeField] float velocidadMovimiento; //velocidad a la que se mueve el enemigo

    Rigidbody2D rb; //referencia del rigidbody del enemigo
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Flip()
    {
        if (estaMirandoDerecha|| !estaMirandoDerecha)
        {
            estaMirandoDerecha = !estaMirandoDerecha;
            Vector2 escalaLocal = transform.localScale;
            escalaLocal.x *= -1f;
            transform.localScale = escalaLocal;
        }
        velocidadMovimiento = velocidadMovimiento * -1f;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= PointA.position.x )
        {
            Flip();
          
        }
        if(transform.position.x <= PointB.position.x)
        {
            Flip();
        }
      velocidadMovimiento = velocidadMovimiento * -1f;
    }
    private void FixedUpdate() // se llama sí o sí 100 veces por segundo se llama también a las funciones de la física
    {
        rb.AddForce(new Vector2(velocidadMovimiento,0f ) );

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.position, 0.5f);
        Gizmos.DrawLine(PointA.position,PointB.position);
    }
}
