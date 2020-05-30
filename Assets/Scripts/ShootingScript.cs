using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public bool isShooting;
    public Transform m_muzzle;
    public Transform m_rotate;
    public GameObject m_shotPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting)
        {
            if (!GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI && Input.GetMouseButtonDown(0))
            {
                Vector3 temp = m_muzzle.position + new Vector3(0, 3.0f, 1.0f);
                GameObject go = GameObject.Instantiate(m_shotPrefab, temp, m_rotate.rotation) as GameObject;
                GameObject.Destroy(go, 1.5f);
            }
        }
        
    }
    
}
