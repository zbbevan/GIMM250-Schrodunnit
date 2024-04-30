using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Button startButton;


    private void Start()
    {
        startButton.onClick.AddListener(() => LoadScene(sceneName));
        StartCoroutine(RewatchAnimation());
    }


    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    IEnumerator RewatchAnimation()
    {
        yield return new WaitForSeconds(20f);
        LoadScene("Intro");
    }
}

