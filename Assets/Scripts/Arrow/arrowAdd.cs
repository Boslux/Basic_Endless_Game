using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowAdd : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(-speed, 0, 0);    
    }
    
}
