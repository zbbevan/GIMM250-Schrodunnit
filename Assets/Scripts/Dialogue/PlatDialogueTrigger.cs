using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject teleporter;

    private void OnMouseDown()
    {
        teleporter.SetActive(true);
        if (PlatDialogueManager.GetInstance() == null || inkJSON == null)
        {
            Debug.LogError("dialogue manager or ink json is null");
            return;
        }

        if (PlatDialogueManager.GetInstance().dialogueIsPlaying)
        {
            Debug.LogError("dialogue is already playing!");
            return;
        }

        PlatDialogueManager.GetInstance().EnterDialogueMode(inkJSON);

    }
}
