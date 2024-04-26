using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    public float speed = 1.5f;
    public float AngleLimit = 75f;
    public bool isRandomStart = false;
    private float random = 0;

    void Awake()
    {
        if (isRandomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }
    void Update()
    {
        float angle = AngleLimit * Mathf.Sin(Time.time * random * speed);
        transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
