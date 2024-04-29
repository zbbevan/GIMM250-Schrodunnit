using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject magGlass;

    
    private void OnMouseDown()
    {
        magGlass.SetActive(true);
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