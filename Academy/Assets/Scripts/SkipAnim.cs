using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipAnim : MonoBehaviour
{
    [SerializeField] private GameObject _triggerCanvas;
    [SerializeField] private GameObject _obj1;
    [SerializeField] private GameObject _obj2;
    [SerializeField] private GameObject _obj3;

    void Start()
    {
        _triggerCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D  other)
    {
        if(other.CompareTag("Player"))
        {
            _triggerCanvas.SetActive(true);
            _obj1.SetActive(false);
            _obj2.SetActive(false);
            _obj3.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _triggerCanvas.SetActive(false);
    }
}
