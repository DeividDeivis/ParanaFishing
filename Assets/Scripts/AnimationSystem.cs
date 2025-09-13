using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationSystem : MonoBehaviour
{
    [SerializeField] private List<Sprite> m_AnimationFrames;
    [SerializeField] private float m_AnimationTime;
    private SpriteRenderer _render;
    private Coroutine _animation;
    private Vector3 initialPos;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        initialPos = transform.localPosition;
        transform.position = new Vector3(initialPos.x, initialPos.y, 10);
    }

    public void SetFrames(List<Sprite> newFrames) 
    {
        m_AnimationFrames = new List<Sprite>(newFrames);
        _render.sprite = m_AnimationFrames[0];
    }

    public void PlayAnim() 
    {
        var frameTime = m_AnimationTime / m_AnimationFrames.Count;
        _animation = StartCoroutine(Animation(frameTime));
    }

    private IEnumerator Animation(float frameTime) 
    {
        int currentFrame = 0;

        while (true)
        {         
            _render.sprite = m_AnimationFrames[currentFrame];

            currentFrame++;
            if (currentFrame >= m_AnimationFrames.Count)
                currentFrame = 0;

            yield return new WaitForSeconds(frameTime);
        }
    }

    public void StopAnim()
    {
        StopCoroutine(_animation);
    }

    public void SetGraph(Vector3 newPos, FishInfo info) 
    {
        _render.color = Color.black;
        transform.position = newPos;
        m_AnimationFrames.Clear();
        SetFrames(info._SpritesAnim);
    }

    public void JumpAnim() 
    {
        DOTween.Sequence().SetEase(Ease.Linear)
            .Append(transform.DOLocalJump(initialPos, 2, 1, 1.5f))
            .Join(_render.DOColor(Color.white, 1.5f))
            .OnComplete(PlayAnim);
    }
}
