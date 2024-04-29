using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using System;
using UnityEngine.SceneManagement;

public class FightDialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private float typingSpeed = 0.04f;
    private Coroutine displayLineCoroutine;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private Story currentStory;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private string nextScene;
    private static FightDialogueManager instance;

    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueToNextLine = false;

    // constants for portrait and speaker tracking
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

    private void Awake()
    {
        if (instance != null) //check for multiple managers
        {
            Debug.LogWarning("More than one dialogue manager in the scene");
        }
        instance = this;
    }

    public static FightDialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        // Set everything to false/inactive for startup
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        currentStory = new Story(inkJSON.text);
        EnterDialogueMode(inkJSON);
    }

    private void Update()
    {
        // Checks for dialogue playing, if not returns out immediately
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        // Opens ink file and starts reading it
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        // Sets everything to false
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);

    }

    private void ContinueStory()
    {
        // Displays next line of dialogue and handles tags to update speaker and portrait
        if (currentStory.canContinue)
        {
            // Checks that typing isn't currently happening, and stops it if it is
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // Handles speaker and portrait tags
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
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    Debug.Log(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag recognized, but not currently handled: " + tag);
                    break;
            }
        }
    }

    // Creates a typing text effect instead of flat displaying the dialogue
    private IEnumerator DisplayLine(string line)
    {
        // Empty text box
        dialogueText.text = "";
        canContinueToNextLine = false;
        // Hide continue icon until text is done scrolling
        continueIcon.SetActive(false);

        // Display letters one at a time
        foreach (char letter in line.ToCharArray())
        {
            // If player submits early, display whole line
            if (InputManager.GetInstance().GetSubmitPressed())
            {
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueToNextLine = true;
        continueIcon.SetActive(true);
    }
}
