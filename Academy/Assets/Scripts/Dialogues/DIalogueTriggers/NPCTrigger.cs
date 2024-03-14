using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;
    [SerializeField] private TextAsset _newInkJSON;
    private bool _isPlayerEnter;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {
        _isPlayerEnter = false;

        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();
    }

    private void Update()
    {
        if(_dialogueWindow.IsPlaying == true || _isPlayerEnter == false)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _dialogueController.EnterDialogueMode(_inkJSON);
            
            _inkJSON = _newInkJSON;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if(collider.CompareTag("Player"))
        {
            _isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if(collider.CompareTag("Player"))
        {
            _isPlayerEnter = false;
        }
    }
}
