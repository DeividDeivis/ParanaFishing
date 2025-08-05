using System.Collections;
using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    private FishingRodController m_Rod;
    private float minFishingRange;
    private float maxFishingRange;
    private float shootSpeed;

    private float rotatioSpeed;

    private bool baitInWater = false;
    private bool shootPressed = false;
    private bool readInput = true;

    private InputSystem_Actions m_Inputs;

    private void Awake()
    {
        //m_Inputs = new InputSystem_Actions();

        //m_Inputs.Player.Jump.started += ctx => CheckBait();

        //m_Inputs.Player.Jump.started += ctx => shootPressed = true;
        //m_Inputs.Player.Jump.canceled += ctx => shootPressed = false;

        minFishingRange = GameManager.instance._settings.MinShootRange;
        maxFishingRange = GameManager.instance._settings.MaxShootRange;
        shootSpeed = GameManager.instance._settings.PowerBarSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rod = GetComponentInChildren<FishingRodController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readInput)        
            CheckBait();
                 
        if (Input.GetKey(KeyCode.Space))
            shootPressed = true;
        if (Input.GetKeyUp(KeyCode.Space))
            shootPressed = false;
    }

    private void CheckBait() 
    {
        if (shootPressed == true) return;

        if (baitInWater) 
        {
            ReturnBait();
        }
        else
        {
            ShootBait();
        }
    }

    private void ShootBait() 
    {
        shootPressed = true;
        StartCoroutine(ShootBaitMiniGame());
    }

    private IEnumerator ShootBaitMiniGame() 
    {
        readInput = false;
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
        readInput = true;
    }

    private void ReturnBait() 
    {
        m_Rod.ReturnBait();
        baitInWater = false;
    }
}
