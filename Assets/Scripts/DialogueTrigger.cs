using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;

    private void OnMouseDown()
    {
        DialoguePlay();
    }

    private void DialoguePlay()
    {
        if (inkJSON != null)
        {
            Debug.Log(inkJSON.text);
        } else
        {
            Debug.LogError("JSON file not loaded correctly");
        }
    }
}
