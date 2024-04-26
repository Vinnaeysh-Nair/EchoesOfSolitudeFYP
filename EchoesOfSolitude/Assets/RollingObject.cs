using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObject : MonoBehaviour
{
    public GameObject Tank;
    Rigidbody rb;
    public float torqueAmount = 5f;
    public bool isRolling = false;
    public AudioSource rollingSound;
    // Start is called before the first frame update
    void Start()
    {
        Tank.SetActive(false);
        rb = Tank.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRolling)
        {
            
            rb.AddTorque(Vector3.forward* -1 * torqueAmount);
            StartCoroutine(StopRolling());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isRolling = true;
        Tank.SetActive(true);
        rollingSound.Play();
    }

    IEnumerator StopRolling()
    {
        //
        yield return new WaitForSeconds(4);
        isRolling = false;
        rb.angularVelocity = Vector3.zero;
    }

}
