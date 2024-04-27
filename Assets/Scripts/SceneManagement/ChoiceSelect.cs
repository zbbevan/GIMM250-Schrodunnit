using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class ChoiceSelect : MonoBehaviour
{/*
    private void Update()
    {
        HandleTags(IntroductionManager.GetInstance().currentStory.currentTags);// gets story file from dialogue manager
    }

    private const string CHOICE_KEY = "choice";
    private void HandleTags(List<string> currentTags)
    {

        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case CHOICE_KEY:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(tagValue); //loads correct scene based on player choice
                    //scene must be named "murder" and "heist" for this to work.
                    break;
                default:
                    Debug.LogWarning("Tag recognized, but not currently handled: " + tag);
                    break;
            }
        }
    }*/
}
    