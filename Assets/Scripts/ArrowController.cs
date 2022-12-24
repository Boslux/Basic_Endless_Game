using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(bulletSpeed*Time.deltaTime, 0, 0);
        Destroy(gameObject,10);
    }

}
