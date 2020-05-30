using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedBreak : MonoBehaviour
{
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    void CleanHit()
    {
        hp--;
    }
}
