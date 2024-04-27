using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionTrigger : MonoBehaviour
{
   [Header("Ink JSON File")]
    [SerializeField] private TextAsset inkJSON;

    private void OnMouseDown()
    {
        if (IntroductionManager.GetInstance() == null || inkJSON == null)
        {
            Debug.LogError("Introduction manager or ink json is null");
            return;
        }

        if (IntroductionManager.GetInstance().dialogueIsPlaying)
        {
            Debug.LogError("Introduction is already playing!");
            return;
        }

        IntroductionManager.GetInstance().EnterDialogueMode(inkJSON);
        
    }
}