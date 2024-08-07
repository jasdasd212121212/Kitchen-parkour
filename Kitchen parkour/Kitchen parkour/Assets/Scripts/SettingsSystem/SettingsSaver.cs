using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSaver : MonoBehaviour
{
    [SerializeField] private GameObject[] _optionsObjects;

    private IOption[] _options;

    private void OnValidate()
    {
        try
        {
            if (_optionsObjects != null)
            {
                if (_optionsObjects.Length > 0)
                {
                    List<GameObject> valid = new List<GameObject>();

                    for (int i = 0; i < _optionsObjects.Length; i++)
                    {
                        if (_optionsObjects[i].GetComponent<IOption>() != null)
                        {
                            valid.Add(_optionsObjects[i]);
                        }
                    }

                    _optionsObjects = valid.ToArray();
                }
            }
        }
        catch { }
    }

    private void Awake()
    {
        _options = new IOption[_optionsObjects.Length];

        for (int i = 0; i < _optionsObjects.Length; i++)
        {
            _options[i] = _optionsObjects[i].GetComponent<IOption>();
            _optionsObjects[i].transform.SetParent(null);
            DontDestroyOnLoad(_optionsObjects[i]);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _options.Length; i++)
        {
            _options[i].Load();
        }
    }

    private void OnDestroy()
    {
        for(int i = 0; i < _options.Length; i++)
        {
            _options[i].Save();
        }

        for (int i = 0; i < _options.Length; i++)
        {
            Destroy(_optionsObjects[i]);
        }
    }
}