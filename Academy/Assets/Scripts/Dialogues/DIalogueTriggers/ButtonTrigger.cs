using Ink.Runtime;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;
    //[SerializeField] private DialogueController _dialogueControllor;

    public void ChangeField(int value)
    {
        Story story = new Story(_inkJSON.text);

        story.variablesState["nameField"] = value;

        Debug.Log(story.variablesState["nameField"]);

        //или

        //var currentStory = _dialogueControllor.CurrentStory;

        //currentStory.variablesState["nameField"] = value;
        //Debug.Log(currentStory.variablesState["nameFiend"]);
    }
}