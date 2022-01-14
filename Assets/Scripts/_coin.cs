using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _coin : MonoBehaviour
{
    bool coinRotationDirection; // true?right:left

    public float coinRotateSpeed = 0f;

    float coinScaleMax = 0.7f;
    float coinScaleMin = 0.07f;

    void Start()
    {
        coinRotateSpeed = 0.7f;
        coinRotationDirection = true;
    }

    void Update()
    {
        rotateCoin();
    }

    private void rotateCoin()
    {
        if (coinRotationDirection)
        {
            this.transform.localScale += Vector3.right * coinRotateSpeed * Time.deltaTime;
            if (this.transform.localScale.x > coinScaleMax)
            {
                coinRotationDirection = !coinRotationDirection;
            }
        }
        if (!coinRotationDirection)
        {
            this.transform.localScale += Vector3.left * coinRotateSpeed * Time.deltaTime;
            if (this.transform.localScale.x < coinScaleMin)
            {
                coinRotationDirection = !coinRotationDirection;
            }
        }
    }
}
