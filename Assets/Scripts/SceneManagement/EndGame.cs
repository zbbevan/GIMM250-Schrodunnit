using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private bool endGame = false;
    void Start()
    {
        StartCoroutine(CloseGameDelayed());
    }

    IEnumerator CloseGameDelayed()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds
        Debug.Log("Closing game after 10 seconds.");
        if (endGame)
        {
            Application.Quit(); // Close the game
        }
        else if (!endGame)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Load the first scene
        }
    }
}
