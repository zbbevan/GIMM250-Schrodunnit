using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensReveal : MonoBehaviour
{
    //This script is how the hidden objects are revealed when the magnifying glass touches them.
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // Start with the hidden object not visible
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected");
        if (other.CompareTag("MagnifyingGlass"))
        {
            spriteRenderer.enabled = true;
        }
        
    }

}
