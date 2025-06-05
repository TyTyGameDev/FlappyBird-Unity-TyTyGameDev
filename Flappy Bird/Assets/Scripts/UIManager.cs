using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkStart();
    }

    public void RestartScene()
    {
        GameManager.Instance.Reset();
        
    }

    public void checkStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Started");
            GameManager.Instance.setIsRestarting();

        }
    }
}
