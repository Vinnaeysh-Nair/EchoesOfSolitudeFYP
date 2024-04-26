using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ElectricBox : MonoBehaviour
{
    public GameObject EuI;
    public bool inRange;
    public string HomeScreenName;
    // Start is called before the first frame update
    void Start()
    {
        EuI.SetActive(false);
        inRange = false;
    }

    private void Update()
    {
        ChangeScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        EuI.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        EuI.SetActive(false);
        inRange = false;
    }

    void ChangeScene()
    {
        if (inRange)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                SwitchScene();
            }
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(HomeScreenName);
    }

}
