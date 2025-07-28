using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    [SerializeField] private float minFishingRange;
    [SerializeField] private float maxFishingRange;
    [SerializeField] private float minShootRange;

    private InputSystem_Actions m_Inputs;

    private void Awake()
    {
        m_Inputs = new InputSystem_Actions();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
