using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;

    private void Update()
    {
        if (InputManager.GetInstance().GetSubmitPressed())
        {
            Debug.Log(inkJSON.text);
            StartCoroutine(DelayInputs());
        }
    }

    IEnumerator DelayInputs() // delays so the program doesnt display text multiple times
    {
        yield return new WaitForSecondsRealtime(1);
    }
}
