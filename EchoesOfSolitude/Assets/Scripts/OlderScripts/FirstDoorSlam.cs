using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstDoorSlam : MonoBehaviour
{
    [Header("DoorStuff")]
    public Animation anim;
    public GameObject Door;

    [Header("LightStuff")]
    public GameObject Torch;
    public float flickerDuration;
    public float minFlickInterval;
    public float maxFlickInterval;
    public float FlickerDelay = .5f;
    Light TorchLight;
    // Start is called before the first frame update
    void Start()
    { 
        anim = Door.GetComponent<Animation>();
        TorchLight = Torch.GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorSlam();
    }

    //Door Slam Stuff

    void DoorSlam()
    {
        anim.Play("Door1_Close");
        this.GetComponent<Collider>().enabled = false;
    }



    IEnumerator FlickerCoroutine()
    {
        yield return new WaitForSeconds(FlickerDelay) ;

        float timer = 0f;
        while (timer < flickerDuration)
        {
            TorchLight.enabled = !TorchLight.enabled;
            float FlickerInterval = Random.Range(minFlickInterval,maxFlickInterval);
            yield return new WaitForSeconds(FlickerInterval);
            timer += FlickerInterval;
        }
        TorchLight.enabled = true;
    }


    public void CallFlickerCoroutine()
    {
        StartCoroutine(FlickerCoroutine());
    }



}
