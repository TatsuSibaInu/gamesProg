using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetScript : MonoBehaviour
{
    public Animator petAnimator;

    public void Awake()
    {
        
    }

    public void Happy() 
    {
        petAnimator.SetTrigger("Happy");
    }

    public void Sad()
    {
        petAnimator.SetTrigger("Sad");
    }

    public void Tierd()
    {
        petAnimator.SetTrigger("Tierd");
    }
    public void Hingry()
    {
        petAnimator.SetTrigger("Hingry");
    }
}
