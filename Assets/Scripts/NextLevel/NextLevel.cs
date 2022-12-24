using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(-speed, 0, 0);
    }
    private void OnTriggerStay2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
