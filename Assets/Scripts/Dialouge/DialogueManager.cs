using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using System;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private float typingSpeed = 0.04f;
    private Coroutine displayLineCoroutine;
    [SerializeField] private GameObject continueIcon;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    //trying to set specific dining room sprites. not working :(
    //[Header("Dining Room Characters")]
    //[SerializeField] private SpriteRenderer bingus;
    //[SerializeField] private SpriteRenderer stubbs;
    //[SerializeField] private SpriteRenderer jean;


    [Header("Character Controllers: Detective")]
    [SerializeField] private Animator detectiveController1;
    [SerializeField] private Animator detectiveController2;
    [SerializeField] private Animator detectiveController3;
    [SerializeField] private Animator detectiveController4;
    [SerializeField] private Animator detectiveController5;
    [SerializeField] private Animator detectiveController6;

    [Header("Character Controllers: Freyja")]
    [SerializeField] private Animator freyjaController;

    [Header("Character Controllers: Jean")]
    [SerializeField] private Animator jeanController;
    [SerializeField] private Animator jeanController2;

    [Header("Character Controllers: Stubbs")]
    [SerializeField] private Animator stubbsController;
    [SerializeField] private Animator stubbsController2;

    [Header("Character Controllers: Bingus")]
    [SerializeField] private Animator bingusController;



    private static DialogueManager instance;
    public Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueToNextLine = false;

    // constants for portrait and speaker tracking
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string SPRITE_TAG = "sprite";

    private void Awake()
    {
        if (instance != null) //check for multiple managers
        {
            Debug.LogWarning("More than one dialogue manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        //set everything to false/inactive for startup
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        // was trying to set them to GO AWAY. they will not disappear on start
        //bingus.GetComponent<SpriteRenderer>().enabled = false;
        //jean.GetComponent<SpriteRenderer>().enabled = false;
        //stubbs.GetComponent<SpriteRenderer>().enabled = false;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //checks for dialogue playing, if not returns out immediately, if is then player must complete dialogue to move on
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode (TextAsset inkJSON)
    {
        // turns off nav buttons, opens ink file and starts reading it
        Buttons.SetActive(false);
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        //turns nav buttons back on and sets everything to false
        resetAnimations();
        Buttons.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    private void ContinueStory()
    {
        //displays next line of dialogue, choices if they exist, and checks tags to update speaker, portrait, and sprites
        if (currentStory.canContinue)
        {
            //checks that typing isnt currently happening, and stops it if it is
            //basically prevents two coroutines from running at the same time
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


    private void DisplayChoices()
    {
        //checks choices and displays them to player
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("more choices given than UI can support. # of choices: " + currentChoices);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private void HandleTags(List<string> currentTags)
    {
        //handles speaker, portrait, and sprite tags
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
                case SPRITE_TAG:
                    // oh god this is so ugly oh god oh no
                    detectiveController1.Play(tagValue);
                    detectiveController2.Play(tagValue);
                    detectiveController3.Play(tagValue);
                    detectiveController4.Play(tagValue);
                    detectiveController5.Play(tagValue);
                    detectiveController6.Play(tagValue);
                    freyjaController.Play(tagValue);
                    stubbsController.Play(tagValue);
                    stubbsController2.Play(tagValue);
                    bingusController.Play(tagValue);
                    jeanController2.Play(tagValue);
                    jeanController.Play(tagValue);
                    Debug.Log(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag recognized, but not currently handled: " + tag);
                    break;
            }
        }
    }

    private IEnumerator SelectFirstChoice()
    {
        //unity decrees there must be a default first choice for players to make a choice
        // this selects the first object in the list
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            //makes choice
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
    }

    //should reset animations to basic ones
    public void resetAnimations()
    {
        detectiveController1.Play("Detective_basic");
        detectiveController2.Play("Detective_basic");
        detectiveController3.Play("Detective_basic");
        detectiveController4.Play("Detective_basic");
        detectiveController5.Play("Detective_basic");
        detectiveController6.Play("Detective_basic");
        freyjaController.Play("freyja_basic");
        stubbsController.Play("stubbs_basic");
        stubbsController2.Play("stubbs_basic");
        bingusController.Play("bingus_basic");
        jeanController2.Play("jean_basic");
        jeanController.Play("jean_basic");
    }
    
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }
    //creates a typing text effect instead of flat displaying the dialogue
    private IEnumerator DisplayLine(string line)
    {
        //empty text box
        dialogueText.text = "";
        canContinueToNextLine = false;
        // hide continue icon and choices until text is done scrolling
        continueIcon.SetActive(false);
        HideChoices();

        //display letters one at a time
        foreach (char letter in line.ToCharArray())
        {
            //if player submits early, display whole line
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
        DisplayChoices();
    }
}
