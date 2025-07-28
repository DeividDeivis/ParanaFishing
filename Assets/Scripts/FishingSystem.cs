using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    private FishingRodController m_Rod;
    private float minFishingRange;
    private float maxFishingRange;
    private float rotatioSpeed;

    private InputSystem_Actions m_Inputs;

    private void Awake()
    {
        m_Inputs = new InputSystem_Actions();

        minFishingRange = GameManager.instance._settings.MinShootRange;
        maxFishingRange = GameManager.instance._settings.MaxShootRange;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rod = GetComponentInChildren<FishingRodController>();
    }

}
