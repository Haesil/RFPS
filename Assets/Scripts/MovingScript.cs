using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject explosion;
    Rigidbody rb;
    Transform cube;
    Transform handle;
    Transform tire;
    Vector3 movement;
    float h;
    float v;
    float handle_x;
    float handle_y;
    float handle_z;
    bool isFinish;
    float end_timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cube = GameObject.Find("Front").GetComponent<Transform>();
        handle = GameObject.Find("handle").GetComponent<Transform>();
        tire = GameObject.Find("Tire1").GetComponent<Transform>();
        handle_x = handle.eulerAngles.x;
        handle_y = handle.eulerAngles.y;
        handle_z = handle.eulerAngles.z;
        isFinish = false;
        end_timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isFinish)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            if (v > 0)
            {
                if (speed < 45.0f)
                    speed += 1.0f;
                else if (speed >= 45.0f)
                    speed = 45.0f;

                tire.Rotate(0, 0, -1*speed);
            }

            else if (v < 0)
            {
                if (speed > 2.0f)
                    speed -= 1.0f;
                else if (speed <= 2.0f)
                    speed = 2.0f;

                tire.Rotate(0, 0, speed);
            }

            else if(v == 0)
            {
                speed = 2.0f;
            }

            if (h > 0)
            {
                if (cube.eulerAngles.y < 300.0f)
                {
                    cube.Rotate(0, 5.0f, 0, Space.Self); //+ 오른쪽 회전 - 왼쪽 회전
                    handle.Rotate(0, 5.0f, 0, Space.Self);
                }


            }

            else if (h == 0)
            {

                if (cube.eulerAngles.y > 270.0f && cube.eulerAngles.y <= 300.0f)
                {
                    cube.Rotate(0, -3.0f, 0, Space.Self); //+ 오른쪽 회전 - 왼쪽 회전
                }
                else if (cube.eulerAngles.y < 270.0f && cube.eulerAngles.y >= 240.0f)
                {
                    cube.Rotate(0, 3.0f, 0, Space.Self); //+ 오른쪽 회전 - 왼쪽 회전
                }
                else
                    cube.eulerAngles = new Vector3(0, 270.0f, 0);
                handle.eulerAngles = new Vector3(handle_x, handle_y, handle_z);

            }
            if (h < 0)
            {
                if (cube.eulerAngles.y > 240.0f)
                {
                    cube.Rotate(0, -5.0f, 0, Space.Self); //+ 오른쪽 회전 - 왼쪽 회전
                    handle.Rotate(0, -5.0f, 0, Space.Self);
                }
            }
            Move(h, v); 
        }
        else
        {
            if (end_timer < 3)
            {

                Move(0, 1);
                end_timer += Time.deltaTime;
            }
            else
                GameObject.Find("UIControlObject").SendMessage("LoadNextScene");
        }
        
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Breakable")
        {
            GameObject.Find("MainCameraObject").SendMessage("Boom");
            GameObject.Find("ExplosionSound").SendMessage("Play");
            GameObject tmp = Instantiate(explosion);
            tmp.transform.position = transform.position;
            tmp.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);

            GameObject.Find("UIControlObject").SendMessage("Restart");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fallen")
        {
            GameObject.Find("MainCameraObject").SendMessage("Fallen");

            GameObject.Find("UIControlObject").SendMessage("Restart");
        }

        if (other.gameObject.tag == "Finish")
        {
            isFinish = true;
            GameObject.Find("MainCameraObject").SendMessage("Boom");
        }

        if(other.gameObject.tag == "Tutorial1")
        {
            GameObject.Find("Canvas").transform.Find("Tutorial1").gameObject.SetActive(true);
            GameObject.Find("MainCameraObject").SendMessage("ModeChange");
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = true;
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (other.gameObject.tag == "Tutorial2")
        {
            GameObject.Find("Canvas").transform.Find("Tutorial2").gameObject.SetActive(true);
            GameObject.Find("MainCameraObject").SendMessage("ModeChange");
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = true;
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (other.gameObject.tag == "Tutorial3")
        {
            GameObject.Find("Canvas").transform.Find("Tutorial3").gameObject.SetActive(true);
            GameObject.Find("MainCameraObject").SendMessage("ModeChange");
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().isUI = true;
            GameObject.Find("UIControlObject").GetComponent<MainSystem>().TimeStop();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
