using UnityEngine;

public class ShipSystem : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private Transform ship;

    // Update is called once per frame
    void Update()
    {
        ship.LookAt(this.transform);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
