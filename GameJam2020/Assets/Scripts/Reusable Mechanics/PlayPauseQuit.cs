using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UItype { play, resume, quit}
public class PlayPauseQuit : MonoBehaviour
{
    [SerializeField] private FadeManager fadeManger;
    [SerializeField] private UItype type;
    [SerializeField] private string scenename;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        sprite.color = new Color(1, 1, 1, 0.5f);
        if (Input.GetMouseButtonDown(0))
        {
            if (type == UItype.play)
            {
                fadeManger.gameObject.SetActive(true);
                fadeManger.FadeSceneOut(scenename);
                //SceneManager.LoadScene(scenename);
            }
            if (type == UItype.quit)
            {
                Application.Quit();
            }
            if (type == UItype.resume)
            {
                //wip
            }
        }
    }
    private void OnMouseExit()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }
    public string GetSceneName(){
        return scenename;
    }
}
