using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadLevel : MonoBehaviour
{
    private Transform cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position.y - cam.position.y) > 100)
        {
            Destroy(gameObject);
        }
    }
}
