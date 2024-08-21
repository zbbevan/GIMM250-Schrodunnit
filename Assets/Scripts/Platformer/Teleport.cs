using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    //This script teleports the player to the top of the next page after they finish the dialogue at the bottom.
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportTarget.transform.position;
        }
    }
}
