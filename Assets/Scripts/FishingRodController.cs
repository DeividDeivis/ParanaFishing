using UnityEngine;

public class FishingRodController : MonoBehaviour
{
    [SerializeField] private Transform m_Rod;
    [SerializeField] private Transform m_Bait;
    [SerializeField] private Transform m_Top;
    [SerializeField] private LineRenderer m_Line;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_Line.SetPositions(new Vector3[] { m_Top.position, m_Bait.position });
    }
}
