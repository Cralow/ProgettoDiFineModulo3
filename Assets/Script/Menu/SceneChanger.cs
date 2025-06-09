using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float sceneTimer;
    public bool isStarting;

    public GameObject[] canvasPanels;


    private void Update()
    {
        if (isStarting)
        {
            sceneTimer -= Time.deltaTime;
            if (sceneTimer < 0)
            {
                SceneManager.LoadScene("Level1");
            }else if(sceneTimer>0 && sceneTimer < 3)
            {
                canvasPanels[0].SetActive(false);
                canvasPanels[1].SetActive(false);
                canvasPanels[2].SetActive(true);
            }
            else if (sceneTimer > 4  && sceneTimer < 6)
            {
                canvasPanels[0].SetActive(false);
                canvasPanels[1].SetActive(true);
            }
            else if (sceneTimer > 7 && sceneTimer < 10)
            {
                canvasPanels[0].SetActive(true);
              
            }





        }
    }
    public void ChangeScene(string sceneName)
    {

        if (sceneName == "Level1")
        {

           isStarting = true;
        }




    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
