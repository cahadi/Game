using UnityEngine;

[RequireComponent(typeof(DialogueMethods))]
public class MethodTag : MonoBehaviour, iTag
{
    public void Calling(string value)
    {
        var dialogueMethods = GetComponent<DialogueMethods>();

        var method = dialogueMethods.GetType().GetMethod(value);

        method.Invoke(dialogueMethods, parameters:null);
    }
}
