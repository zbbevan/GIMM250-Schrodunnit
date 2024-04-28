using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject checkpoint; 

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkpoint.transform.position = player.transform.position; 
            Debug.Log("Checkpoint set");
        }
    }
}
