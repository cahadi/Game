using UnityEngine;

public class SpeakerTag : MonoBehaviour, iTag
{
    public void Calling(string value)
    {
        var dialogueWindow = GetComponent<DialogueWindow>();
        dialogueWindow.SetName(value);
    }
}
