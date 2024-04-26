using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDoor : MonoBehaviour
{
    [SerializeField] private Animator DoorAnim = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private string DoorOpenName;
    [SerializeField] private string DoorCloseName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                DoorAnim.Play(DoorOpenName, 0, 0.0f);

            }
            else if (closeTrigger)
            {
                DoorAnim.Play(DoorCloseName,0,0.0f);
            }
        }
    }
}
