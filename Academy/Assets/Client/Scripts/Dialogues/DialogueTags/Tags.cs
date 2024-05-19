using System.Collections.Generic;
using UnityEngine;

[RequireComponent(requiredComponent:typeof(SpeakerTag),
requiredComponent2:typeof(MethodTag),
requiredComponent3:typeof(CooldownTag))]
public class Tags : MonoBehaviour
{
    private readonly Dictionary<string, iTag> _map = new ();

    private void Start()
    {
        _map.Add("speaker", GetComponent<SpeakerTag>());
        _map.Add("method", GetComponent<MethodTag>());
        _map.Add("cooldown", GetComponent<CooldownTag>());
    }

    public iTag GetValue(string key)
    {
        return _map.GetValueOrDefault(key);
    }
}
