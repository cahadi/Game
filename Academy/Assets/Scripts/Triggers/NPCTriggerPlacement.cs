using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerPlacement : MonoBehaviour
{
    [SerializeField] GameObject[] _objActive;
    [SerializeField] GameObject[] _objInactive;
    void Start()
    {
        if(_objActive.Length != 0)
        {
            foreach(GameObject _objA in _objActive)
                _objA.SetActive(true);
        }

        if(_objInactive.Length != 0)
        {
            foreach(GameObject _objI in _objInactive)
                _objI.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(this);
    }
}
