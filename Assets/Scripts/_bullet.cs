using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _bullet : MonoBehaviour
{
    float bulletActive_StartTime = 0f;
    float bulletActive_ElapsedTime = 0f;
    float bulletActive_LifeTime = 0f;

    void Awake()
    {
        bulletActive_LifeTime = 3f;
    }

    void OnEnable()
    {
        bulletActive_StartTime = Time.time;
    }


    void Update()
    {
        bulletActive_ElapsedTime = Time.time - bulletActive_StartTime;

        if (bulletActive_ElapsedTime > bulletActive_LifeTime)
        {
            this.gameObject.SetActive(false);
        }
    }
}
