using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class swordController : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}

