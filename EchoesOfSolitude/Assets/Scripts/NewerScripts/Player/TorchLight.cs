using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public GameObject TorchHand;
    public bool isCarry;
    AnimationManager animationManager;
    SoundManager soundManager;
    private Animator TorchAnim;

    // Start is called before the first frame update
    void Start()
    {
        isCarry = false;
        animationManager = GameObject.FindObjectOfType<AnimationManager>();
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        TorchAnim = TorchHand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            soundManager.PlaySound("FlashLight");
            isCarry = !isCarry;
        }

        if (isCarry)
        {
            //animationManager.TorchLightOn(TorchHand);
            TorchAnim.SetBool("isCarry" , true);
        }
        else if (!isCarry)
        {
            //animationManager.TorchLightOff(TorchHand);
            TorchAnim.SetBool("isCarry", false);
        }
    }
}
