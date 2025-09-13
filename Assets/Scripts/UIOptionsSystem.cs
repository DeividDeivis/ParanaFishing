using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsSystem : MonoBehaviour
{
    [SerializeField] private ToggleGroup _options;
    private List<Toggle> _toggles;
    [SerializeField] private int _activeOption = 0;
    public int ActiveOption => _activeOption;
    public Toggle ActiveToggle 
    {
        get 
        {
            var activeToggle = _toggles[_activeOption];
            return activeToggle;
        }
    }

    private void Start()
    {
        _toggles = _options.GetComponentsInChildren<Toggle>().ToList();
        _toggles[_activeOption].isOn = true;
    }

    public void ChangeUp() 
    {
        _activeOption++;
        if (_activeOption >= _toggles.Count)
            _activeOption = _toggles.Count - 1;

        _toggles[_activeOption].isOn = true;
    }

    public void ChangeDown()
    {
        _activeOption--;
        if (_activeOption <= 0)
            _activeOption = 0;

        _toggles[_activeOption].isOn = true;
    }
}
