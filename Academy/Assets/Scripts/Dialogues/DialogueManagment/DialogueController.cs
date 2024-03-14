using UnityEngine;
using Ink.Runtime;
using System.Collections;
using System;

[RequireComponent(requiredComponent: typeof(DialogueWindow), requiredComponent2: typeof(DialogueTag))]
public class DialogueController : MonoBehaviour
{
    private DialogueWindow _dialogueWindow;
    private DialogueTag _dialogueTag;

    public Story CurrentStory {get; private set;}
    private Coroutine _displayLineCoroutine;

    private void Awake()
    {
        _dialogueTag = GetComponent<DialogueTag>();
        _dialogueWindow = GetComponent<DialogueWindow>();

        _dialogueTag.Init();
        _dialogueWindow.Init();
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    private void Update()
    {
        if(_dialogueWindow.IsStatusAnswer == true ||
        _dialogueWindow.IsPlaying == false ||
        _dialogueWindow.CanContinueToNextLine == false)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset intJSON)
    {
        
        _dialogueWindow.SetActive(true);
        CurrentStory = new Story(intJSON.text);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(_dialogueWindow.CoolDownNewLetter);

        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }

    private void ContinueStory()
    {
        if(CurrentStory.canContinue == false)
        {
            StartCoroutine(routine: ExitDialogueMode());
            return;
        }

        if(_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }

        _displayLineCoroutine = StartCoroutine(routine: _dialogueWindow.DisplayLine(CurrentStory));

        try
        {
            _dialogueTag.HandleTags(CurrentStory.currentTags);
        }
        catch(ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        _dialogueWindow.MakeChoice();

        CurrentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }
}
