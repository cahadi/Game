using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject _visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJSON;

    [Header("New Ink JSON")]
    [SerializeField] private TextAsset _newInkJSON;
    private bool _isPlayerEnter;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {
        _visualCue.SetActive(false);
        _isPlayerEnter = false;

        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();
    }

    private void Update()
    {
        if (_dialogueWindow.IsPlaying || !_isPlayerEnter)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_inkJSON != null)
            {
                _dialogueController.EnterDialogueMode(_inkJSON);
                _inkJSON = _newInkJSON;
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _visualCue.SetActive(true);
            _isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _visualCue.SetActive(false);
            _isPlayerEnter = false;
        }
    }
}