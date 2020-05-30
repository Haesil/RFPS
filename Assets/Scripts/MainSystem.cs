using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSystem : MonoBehaviour
{
    public float delayedSec;
    float timer;
    bool isRestart;
    bool isEscapeKey;
    bool isClear;
    public int sceneNum;
    public bool isUI;
    public static MainSystem instance = null;
    bool isPause;
    int stageNum;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            delayedSec = 3.0f;
            timer = 0;
            isRestart = false;
            isEscapeKey = false;
            isUI = false;
            isPause = false;
            isClear = false;
            sceneNum = 0;
            stageNum = 3;
        }
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (isRestart)
        {
            timer += Time.deltaTime;
            if (timer > delayedSec)
            {
                switch (sceneNum)
                {
                    case 1:
                        timer = 0.0f;
                        SceneManager.LoadScene("Level1");
                        isRestart = false;
                        break;
                    case 2:
                        timer = 0.0f;
                        SceneManager.LoadScene("Level2");
                        isRestart = false;
                        break;

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isEscapeKey && !isUI)
            {
                if (sceneNum > 0)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    GameObject.Find("MainCameraObject").SendMessage("ModeChange");
                }
                isEscapeKey = true;
                isUI = true;
                GameObject.Find("Canvas").transform.Find("ExitQ").gameObject.SetActive(true);
                TimeStop();
            }
            else
                PushNo();
        }
        if (isClear)
        {
            timer += Time.deltaTime;
            if (timer > delayedSec)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                timer = 0;
                isClear = false;
                SceneManager.LoadScene("Main");
            }
        }
    }
    void Restart()
    {
        isRestart = true;
    }

    public void LoadNextScene()
    {
        sceneNum = (sceneNum + 1) % stageNum;
#if UNITY_EDITOR
        Debug.Log("sceneNum" + sceneNum);
#endif
        switch (sceneNum)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                timer = 0.0f;
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                timer = 0.0f;
                Clear();
                break;

        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void PushNo()
    {
        isEscapeKey = false;
        GameObject.Find("Canvas").transform.Find("ExitQ").gameObject.SetActive(false);
        isUI = false;
        TimeStop();
        Debug.Log(sceneNum);
        if (sceneNum > 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void TimeStop()
    {
        if (!isPause)
        {
            isPause = true;
            Debug.Log("TimeStop!");
            Time.timeScale = 0.0f;
        }
        else
        {
            isPause = false;
            Debug.Log("TimeNonStop!");
            Time.timeScale = 1.0f;
        }
    }
    void Clear()
    {
        GameObject.Find("Canvas").transform.Find("Clear").gameObject.SetActive(true);
        isClear = true;
    }
    private void OnApplicationQuit()
    {
        instance = this;
        delayedSec = 3.0f;
        timer = 0;
        isRestart = false;
        isEscapeKey = false;
        isUI = false;
        isPause = false;
        isClear = false;
        sceneNum = 0;
        stageNum = 3;
    }
}