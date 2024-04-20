using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMagnifyingGlass : MonoBehaviour
{

    //This code was found in a video by Alexander Zotov on YouTube. https://www.youtube.com/watch?v=UJ4w5V5aTP4

    private Vector2 mousePosition;
    private Vector2 dragOffset;

    private void OnMouseDown()
    {
        dragOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition - dragOffset;
    }
}
