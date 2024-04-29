using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{   void Start()
    {
        StartCoroutine(CloseGameDelayed());
    }

    IEnumerator CloseGameDelayed()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds
        Debug.Log("Closing game after 10 seconds.");
        Application.Quit(); // Close the game
    }
}
