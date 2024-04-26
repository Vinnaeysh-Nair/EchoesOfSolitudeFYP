using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBodySwing : MonoBehaviour
{
    PendulumScript _pendulum;
    public float DecreaseSpeedRate;
    private float CurrentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _pendulum = GetComponent<PendulumScript>();
        CurrentSpeed = _pendulum.speed;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeed = DecreaseSpeedRate * Time.deltaTime;
        Debug.Log("Current Speed" + CurrentSpeed);
        if (CurrentSpeed <= 0) 
        {
            this.gameObject.SetActive(false);
        }
    }
}
