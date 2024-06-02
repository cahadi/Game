using UnityEngine;

public class SkipDialogues : MonoBehaviour
{
    private DialogueWindow _dialogueWindow;
    public void Skip()
    {
        _dialogueWindow = GetComponent<DialogueWindow>();
        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }
}
