using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvukGrenade : MonoBehaviour
{
    public AudioSource grenade;

    public void Grenade()
    {
        grenade.Play();
    }
}
