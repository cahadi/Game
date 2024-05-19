using UnityEngine;

public class SkipAnim : MonoBehaviour
{
    [SerializeField] GameObject[] _objInactive;
    [SerializeField] GameObject[] _objActive;
    [SerializeField] private GameObject _triggerCanvas;

    void Start()
    {
        _triggerCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D  other)
    {
        _triggerCanvas.SetActive(true);
        if(other.CompareTag("Player"))
        {
            if(_objInactive.Length != 0 || _objActive.Length != 0)
            {
                Invoke("HideElement", 1f);
                Invoke("HideAnim", 2f);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _triggerCanvas.SetActive(false);
        Destroy(this);
    }

    private void HideElement()
    {
        if(_objInactive.Length != 0)
        {
            foreach(GameObject _objI in _objInactive)
                _objI.SetActive(false);
        }
        if(_objActive.Length != 0)
        {
            foreach(GameObject _objA in _objActive)
                _objA.SetActive(true);
        }
    }

    private void HideAnim()
    {
        _triggerCanvas.SetActive(false);
    }
}
