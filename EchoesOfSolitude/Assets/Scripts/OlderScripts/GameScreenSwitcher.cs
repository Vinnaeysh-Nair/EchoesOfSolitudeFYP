using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScreenSwitcher : MonoBehaviour
{
    public string HomeScreenName;
    // Update is called once per frame

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SwitchScene();
        }
            
    }
    public void SwitchScene()
    {

            SceneManager.LoadScene(HomeScreenName);
        
    }
}
