using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnim : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject _triggerCanvas;

    void Start()
    {
        _triggerCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D  other)
    {
        if(other.CompareTag("Player"))
        {
            _triggerCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _triggerCanvas.SetActive(false);
        Destroy(this);
    }
}
