using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningTrigger : MonoBehaviour
{
    [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject[] theseNerds;


    private void OnMouseDown()
    {
        for (int i = 0; i < theseNerds.Length; i++)
        {
            theseNerds[i].SetActive(true);
        }
        if (DialogueManager.GetInstance() == null || inkJSON == null)
        {
            Debug.LogError("dialogue manager or ink json is null");
            return;
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Debug.LogError("dialogue is already playing!");
            return;
        }

        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);

    }
}
