using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class PlayerRayCastFlash : MonoBehaviour
{
    [Header("Raycast stuff")]
    public Camera cam;
    public float rayDist;
    public LayerMask layerFlash1;
    public LayerMask layerFlash2;
    public bool HasTakenPhoto;

    [Header("UI components")]
    public bool isCam;
    public GameObject CameraUI;
    public bool isPhoto;

    [Header("PostProcessing")]
    public Volume volume;
    public CanvasGroup canvasGroupAlpha;
    public bool isFlash = false;

    [Header("GirlJumpScare Events")]
    public GameObject GirlJumpScare;
    public bool playSound;
    public bool isKeyDropped;
    public bool isDissapearBody;
    private bool object1PhotoTaken = false;
    private bool object2PhotoTaken = false;
    //private bool isDoor1 = false;
    private void Start()
    {
        CameraUI.SetActive(false);
        isPhoto = false;
        HasTakenPhoto = false;
        isKeyDropped = false;
        GirlJumpScare.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        RayCastFlashFunc();
        CamFlashEffect();

    }

    void RayCastFlashFunc()
    {
        if (!HasTakenPhoto)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDist, layerFlash1) && !object1PhotoTaken)
            {
                    CameraUI.SetActive(true);
                    isPhoto = true;
            }
            else if (Physics.Raycast(ray, out hit, rayDist, layerFlash2) && !object2PhotoTaken)
            {
                CameraUI.SetActive(true);
                isPhoto = true;
            }
            else
            {
                CameraUI.SetActive(false);
                isPhoto = false;
            }
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.blue);

            TakePhoto();
        }
    }
    void TakePhoto()
    {
        if (isPhoto && Input.GetKeyDown(KeyCode.F))
        {
            CamFlashed();
            isPhoto=false;
            CameraUI.SetActive(false);

            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, rayDist, layerFlash1))
            {
                object1PhotoTaken = true;
            }
            else if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, rayDist, layerFlash2))
            {
                object2PhotoTaken = true;
            }
        }
    }

    void CamFlashed()
    {
        volume.GetComponent<Volume>().weight = 1f;
        isFlash = true;

        canvasGroupAlpha.alpha = 1f;
    }

    void CamFlash()
    {
        Time.timeScale = .5f;
        canvasGroupAlpha.alpha = canvasGroupAlpha.alpha - Time.deltaTime * 2;
        volume.GetComponent<Volume>().weight -= Time.deltaTime * 2;

        if (canvasGroupAlpha.alpha <= 0)
        {
            volume.weight = 0f;
            canvasGroupAlpha.alpha = 0;
            Time.timeScale = 1f;
            isFlash = false;
        }
    }

    void CamFlashEffect()
    {
        if (isFlash)
        {
            CamFlash();
            isKeyDropped = true;
            if (object2PhotoTaken)
            {
                StartCoroutine(DissapearBody());
            }
        }
    }


    IEnumerator DissapearBody()
    {
        
        GirlJumpScare.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GirlJumpScare.SetActive(false);
        isDissapearBody = true;
    }
}
