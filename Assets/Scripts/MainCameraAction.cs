using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraAction : MonoBehaviour
{

    public GameObject motorcycle;
    GameObject cam;
    Vector3 cam_pos;
    bool isBoom;


    int cameraMode; // 0 - 기본 1 - fps 2 - zoom in 우클릭으로 변경

    float rotX;
    float rotY;
    public float offset_x;
    public float offset_y;
    public float offset_z;
    private void Start()
    {
        isBoom = false;
        cam = GameObject.Find("Main Camera");
        cameraMode = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        cam_pos.x = motorcycle.transform.position.x + offset_x;
        cam_pos.y = motorcycle.transform.position.y + offset_y;
        cam_pos.z = motorcycle.transform.position.z + offset_z;

        if (!GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI
            && Input.GetMouseButtonDown(1))
        {
            cameraMode = (cameraMode + 1) % 2;
        }
            
        if(!GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI)
        {
            if (cameraMode == 0)
            {
                cam.GetComponent<Camera>().fieldOfView = 60;
                motorcycle.GetComponent<ShootingScript>().isShooting = false;

                Color color = GameObject.Find("Crosshair").GetComponent<Image>().color;
                color.a = 0.0f;
                GameObject.Find("Crosshair").GetComponent<Image>().color = color;
                transform.eulerAngles = new Vector3(0, 0, 0);
                cam.transform.eulerAngles = new Vector3(20.0f, 0, 0);
            }
            else if (cameraMode == 1)
            {
                Color color = GameObject.Find("Crosshair").GetComponent<Image>().color;
                color.a = 1.0f;
                GameObject.Find("Crosshair").GetComponent<Image>().color = color;

                motorcycle.GetComponent<ShootingScript>().isShooting = true;

                rotX = Input.GetAxis("Mouse Y") * 1.0f;
                rotY = Input.GetAxis("Mouse X") * 1.0f;

                transform.localRotation *= Quaternion.Euler(0, rotY, 0);
                if (cam.transform.eulerAngles.x <= 20.0f)
                    cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
                else if (cam.transform.eulerAngles.x < 350.0f)
                    cam.transform.eulerAngles = new Vector3(20.0f, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
                else
                    cam.transform.eulerAngles = new Vector3(0.0f, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            }
        }
        

        if (!isBoom)
            transform.position = cam_pos;
    }

    void Boom()
    {
        cam_pos.y = transform.position.y + 5;
        cam_pos.z = transform.position.z - 10;
        transform.eulerAngles = new Vector3(0, 0, 0);
        cam.transform.eulerAngles = new Vector3(20.0f, 0, 0);
        cameraMode = 0;
        isBoom = true;
        transform.position = cam_pos;
    }

    void Fallen()
    {
        cam_pos.y = transform.position.y + 5;
        cam_pos.z = transform.position.z - 10;
        transform.eulerAngles = new Vector3(0, 0, 0);
        cam.transform.eulerAngles = new Vector3(20.0f, 0, 0);
        cameraMode = 0;
        isBoom = true;
        transform.position = cam_pos;
    }

    void ModeChange()
    {
        cameraMode = 0;
    }
}
