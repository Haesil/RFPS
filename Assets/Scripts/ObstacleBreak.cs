using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBreak : MonoBehaviour
{
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void CleanHit()
    {
        hp--;
    }
    
}
