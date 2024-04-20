using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensReveal : MonoBehaviour
{
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
