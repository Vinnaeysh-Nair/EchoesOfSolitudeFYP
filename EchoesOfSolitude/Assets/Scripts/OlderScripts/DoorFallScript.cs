using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFallScript : MonoBehaviour
{
    public GameObject Door;
    public float RotAmount = 90f;
    public float RotSpeed = 2f;
    public bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorFallMethod();
    }

    private void OnTriggerEnter(Collider other)
    {
        isRotating = true;
    }

    public void DoorFallMethod()
    {
        if (isRotating)
        {
            float rotation = RotAmount * RotSpeed * Time.deltaTime;
            Door.transform.Rotate(Vector3.right, rotation);
            StartCoroutine(StopDoorFall());
        }
    }

    IEnumerator StopDoorFall()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
