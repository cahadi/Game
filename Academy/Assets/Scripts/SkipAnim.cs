using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnim : MonoBehaviour
{
    [SerializeField] GameObject[] _objInactive;
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
            if(_objInactive.Length != 0)
            {
                foreach(GameObject _objI in _objInactive)
                    _objI.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _triggerCanvas.SetActive(false);
        Destroy(this);
    }
}
