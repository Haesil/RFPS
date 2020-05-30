using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial1Exit()
    {
        GameObject.Find("Tutorial1").SetActive(false);
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = false;
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Tutorial2Exit()
    {
        GameObject.Find("Tutorial2").SetActive(false);
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = false;
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Tutorial3Exit()
    {
        GameObject.Find("Tutorial3").SetActive(false);
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = false;
        GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
