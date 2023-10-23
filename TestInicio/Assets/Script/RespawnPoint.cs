using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField] Transform lastRespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        lastRespawnPoint = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.F) )
        {

        }
    }
    public Transform getLastRespawnPoint()

    {
        return lastRespawnPoint;
    }
}
