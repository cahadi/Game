using System;
using UnityEngine;

public class CooldownTag : MonoBehaviour, iTag
{
    public void Calling(string value)
    {
        float number = (float)Convert.ToDouble(value.Replace(oldValue:".", newValue:","));

        var dialogueWindow = GetComponent<DialogueWindow>();

        try
        {
            dialogueWindow.SetCoolDown(number);
        }
        catch(ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
