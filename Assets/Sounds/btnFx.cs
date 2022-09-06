using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFx : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip clickMenuFx;
    public AudioClip HoverMenuFx;


    public void ClickSound()
    {
        myFx.PlayOneShot(clickMenuFx);
    }
    public void HoverSound()
    {
       myFx.PlayOneShot(HoverMenuFx);
    }
}
