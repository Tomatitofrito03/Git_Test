using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    private float movimientoHorizontal;
    private float movimientoVertical;

    private bool estaMirandoDerecha;

    [SerializeField] int movementSpeed;
    [SerializeField] int fuerzaSalto;

    [SerializeField] private Transform groundCheck;
    [SerializeField] LayerMask layerSuelo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        estaMirandoDerecha = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Start()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        movimientoVertical = Input.GetAxisRaw("Vertical");
        /*
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(Vector2.right * movementSpeed);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(Vector2.left * movementSpeed);
                }
        */

        Flip();

        //estaEnElSuelo();
        if (movimientoVertical > 0f && estaEnElSuelo())
            rb.AddForce(new Vector2(0, fuerzaSalto));

        if (movimientoHorizontal != 0f)
        {
            animator.SetBool("estaCorriendo", true);
            audioSource.Play();
        }
        else
        {
            animator.SetBool("estaCorriendo" , false);
            audioSource.Stop();
        }
        
    }

    private void FixedUpdate() // se llama sí o sí 100 veces por segundo se llama también a las funciones de la física
    {
        //rb.AddForce(new Vector2(movimientoHorizontal , 0) * movementSpeed);//
        rb.velocity = new Vector2(movimientoHorizontal * movementSpeed,rb.velocity.y);

    }

    private void Flip()
    {
        if(estaMirandoDerecha && movimientoHorizontal < 0f || !estaMirandoDerecha && movimientoHorizontal > 0f )
        {
            estaMirandoDerecha = !estaMirandoDerecha;
            Vector2 escalaLocal = transform.localScale;
            escalaLocal.x *= -1f;
            transform.localScale = escalaLocal;
        }
    }
    private bool estaEnElSuelo()
    {
     return Physics2D.OverlapCircle(groundCheck.position, 0.2f, layerSuelo);
    }

}
