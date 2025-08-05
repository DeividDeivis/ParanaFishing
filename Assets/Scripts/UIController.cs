using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider powerBar;

    #region Singleton
    private static UIController _instance;
    public static UIController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<UIController>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    #endregion

    public void SetPowerBar(float value) 
    {
        powerBar.value = value;
    }
}
