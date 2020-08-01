using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager instance = null;

    [SerializeField] GameObject[] Panels;
    [SerializeField] string SceneToLoad;
    [SerializeField] FadeManager fadeManager;

    CameraMovement cam;

    int index = 0;
    // Start is called before the first frame update

    void Awake()
    {   
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        CameraMovement.FinishedMoving += ActivateNextPanel;
    }

    void Start()
    {
        cam = Camera.main.gameObject.GetComponent<CameraMovement>();
        cam.InitialFrame(Panels[index].transform.position);
    }

    void OnDestroy()
    {
        CameraMovement.FinishedMoving -= ActivateNextPanel;
    }

    public void NextPanel()
    {
        if (index + 1 < Panels.Length){
            cam.MoveCameraToNextPanel(Panels[++index].transform.position);
            Debug.Log("loading panel: " + (index));
        }
        else{
            Debug.Log("fading");
            fadeManager.gameObject.SetActive(true);
            fadeManager.FadeSceneOut(SceneToLoad);
            //SceneManager.LoadScene(SceneManager.GetSceneByName(SceneToLoad).buildIndex);
        }
            
    }

    void ActivateNextPanel()
    {
        Debug.Log("Index: " + index);
        Panels[index].GetComponent<Panel>().Activate();  
    }

}
