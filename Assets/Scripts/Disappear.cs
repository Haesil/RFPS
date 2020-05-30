using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    float dTimer;

    // Start is called before the first frame update
    void Start()
    {
        dTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dTimer < 1.5f)
        {
            dTimer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
