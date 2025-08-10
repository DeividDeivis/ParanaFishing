using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishingSystem : MonoBehaviour
{
    private FishingRodController m_Rod;
    private float minFishingRange;
    private float maxFishingRange;
    private float shootSpeed;

    public bool baitInWater = false;
    public bool shootPressed = false;
    public bool catchFish = false;
    public static Action OnFishBait;

    public Action<float> FishingProgress;
    private float strain = 0;
    public Action<bool> FishingComplete;

    private void Awake()
    {
        minFishingRange = GameManager.instance.Settings.MinShootRange;
        maxFishingRange = GameManager.instance.Settings.MaxShootRange;
        shootSpeed = GameManager.instance.Settings.PowerBarSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rod = GetComponentInChildren<FishingRodController>();
    }

    public void ShootBait() 
    {
        shootPressed = true;
        catchFish = false;
        StartCoroutine(ShootBaitMiniGame());
    }

    private IEnumerator ShootBaitMiniGame() 
    {
        bool loop = false;
        float currentForce = 0f;

        while (shootPressed) 
        {
            if (!loop)
            {
                currentForce += shootSpeed * Time.deltaTime;
                if (currentForce >= 1)
                    loop = true;
            }
            else
            {
                currentForce -= shootSpeed * Time.deltaTime;
                if (currentForce <= 0)
                    shootPressed = false;
            }
            UIController.instance.SetPowerBar(currentForce);
            yield return null;
        }

        Debug.Log("Force Percentage: " + currentForce);
        float diff = maxFishingRange - minFishingRange;
        float distance = minFishingRange + (diff * currentForce);
        m_Rod.ShootBait(distance);

        yield return new WaitForSeconds(3);
        baitInWater = true;
    }

    public void ReturnBait() 
    {
        m_Rod.ReturnBait();
        baitInWater = false;
    }

    public void WaitToCatch() 
    {
        StartCoroutine(FishingMiniGame());
    }

    private IEnumerator FishingMiniGame() 
    {
        while (!baitInWater) 
        {
            yield return null;
        }

        while (!catchFish)
        {
            float timeToWait = Random.Range(1, 3);
            yield return new WaitForSeconds(timeToWait);

            float cathChance = Random.Range(0, 100);
            Debug.Log($"FISH CATH CHANCE: {cathChance}");
            if (cathChance <= 15) 
            {
                catchFish = true;
                OnFishBait?.Invoke();
                Debug.Log("FISH IN BAIT");
            }
        }
    }

    public void CatchAnim() 
    {
        m_Rod.PushAnim();
    }

    public void PullFishingRod()
    {
        m_Rod.PullAnim();
        strain -= .15f;
    }

    public void CatchFishMiniGame() 
    {
        m_Rod.PushAnim();
        StartCoroutine(CatchingFish());
    }

    private IEnumerator CatchingFish()
    {
        float progression = 0;
        strain = 0;
        while (strain < 1 && progression < 100) 
        {
            strain += .1f;
            progression += 1;
            FishingProgress?.Invoke(strain);

            if (strain >= 1)
                FishingComplete?.Invoke(false);
            else if(progression >= 100)
                FishingComplete?.Invoke(true);

            yield return new WaitForSeconds(.15f);
        }

        m_Rod.ReturnBait();
    }
}
