using DG.Tweening;
using System;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class FishingRodController : MonoBehaviour
{
    [SerializeField] private Transform m_Rod;
    [SerializeField] private Transform m_Bait;
    [SerializeField] private Transform m_Top;
    [SerializeField] private LineRenderer m_Line;

    public static Action<Vector3> OnBaitInWater;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Bait.transform.SetParent(m_Top);
        m_Bait.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        m_Line.SetPositions(new Vector3[] { m_Top.position, m_Bait.position });
    }

    public void ShootBait(float distance) 
    {
        Sequence shootAnim = DOTween.Sequence().SetEase(Ease.Linear);
        shootAnim
            .Append(m_Rod.DOLocalRotate(new Vector3(-30,0,0), .5f).SetLoops(2, LoopType.Yoyo).OnComplete(()=> m_Bait.transform.parent = null))
            .Append(m_Rod.DOLocalRotate(new Vector3(15, 0, 0), .5f))
            .Join(m_Bait.DOLocalMoveZ(distance, 3f))            
            .Join(m_Bait.DOLocalMoveY(-1.47f, 1f).SetDelay(2f))
            .OnComplete(()=> OnBaitInWater?.Invoke(m_Bait.transform.position));
    }

    public void ReturnBait() 
    {
        Sequence ReturnAnim = DOTween.Sequence().SetEase(Ease.Linear);
        ReturnAnim
            .Append(m_Rod.DOLocalRotate(new Vector3(-30, 0, 0), .5f))
            .Append(m_Rod.DOLocalRotate(new Vector3(0, 0, 0), 1f))
            .Join(m_Bait.DOMove(m_Top.position, 1f).OnComplete(() => {
                m_Bait.transform.SetParent(m_Top);
                m_Bait.transform.localPosition = Vector3.zero;
            }));          
    }
}
