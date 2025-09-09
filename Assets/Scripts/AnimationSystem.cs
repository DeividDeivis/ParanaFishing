using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    [SerializeField] private List<Sprite> m_AnimationFrames;
    [SerializeField] private float m_AnimationTime;
    private SpriteRenderer _render;
    private Coroutine _animation;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
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
}
