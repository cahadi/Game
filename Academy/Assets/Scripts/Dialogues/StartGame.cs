using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;
    private DialogueController _dialogueController;
    // [SerializeField] private GameObject obj;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(_inkJSON != null)
        {
            _dialogueController = FindObjectOfType<DialogueController>();
            _dialogueController.EnterDialogueMode(_inkJSON);
        }
        else
            return;
            
        Destroy(this);
    }
}
