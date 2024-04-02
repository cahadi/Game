using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject _visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJSON;

    [Header("New Ink JSON")]
    [SerializeField] private TextAsset _newInkJSON;

    [Header("Sister")]
    [SerializeField] private GameObject[] _sisters;

    [Header("Skip Animation")]
    [SerializeField] private GameObject[] _skipAnim;

    private bool _isPlayerEnter;

    private DialogueController _dialogueController;
    private DialogueWindow _dialogueWindow;

    private void Start()
    {
        _visualCue.SetActive(false);
        _isPlayerEnter = false;

        _dialogueController = FindObjectOfType<DialogueController>();
        _dialogueWindow = FindObjectOfType<DialogueWindow>();

        if (_sisters.Length != 0)
        {
            _skipAnim[0].SetActive(false);
        }
    }

    private void Update()
    {
        if (_sisters.Length == 0 && _skipAnim.Length == 0)
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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _visualCue.SetActive(true);
            _isPlayerEnter = true;

            if (_sisters.Length != 0)
            {
                _dialogueController.EnterDialogueMode(_inkJSON);
                _skipAnim[0].SetActive(true);
                _sisters[0].SetActive(false);
                _skipAnim[0].SetActive(false);
                _inkJSON = _newInkJSON;
                Destroy(_sisters[0]);
            }
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