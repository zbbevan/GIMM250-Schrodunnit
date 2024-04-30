using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToSkip : MonoBehaviour
{
    [SerializeField] private Button skip;

    private void Start()
    {
        skip.onClick.AddListener(Skip);
    }

    private void Skip()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
