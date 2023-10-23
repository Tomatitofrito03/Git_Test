using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-5); //nueva posicion de la camara
    private Vector3 velocidad = Vector3.zero; //velocidad a la que se mueve la camara
    private float cameraMovementSmooth = 0.25f; //variacoion de la velocidad

    [SerializeField] private Transform target; //el transform del personaje
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 posicionObjetivo = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, posicionObjetivo, ref velocidad, cameraMovementSmooth);
        }
    }
}
