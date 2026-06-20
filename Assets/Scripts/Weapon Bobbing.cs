using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class WeaponBobbing : MonoBehaviour
{
    public float bobSpeed = 8f;      // Tốc độ lắc
    public float bobAmount = 0.05f;  // Biên độ lắc

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

        if (isMoving)
        {
            float x = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
            float y = Mathf.Abs(Mathf.Cos(Time.time * bobSpeed)) * bobAmount;

            transform.localPosition = startPos + new Vector3(x, y, 0);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                startPos,
                Time.deltaTime * bobSpeed
            );
        }
    }
}

