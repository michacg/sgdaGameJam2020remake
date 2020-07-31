using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UItype { play, resume, quit }
public class PlayPauseQuit : MonoBehaviour
{
    [SerializeField] private UItype type;
    [SerializeField] private string scenename;
    [SerializeField] private FadeManager fadeManager;

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
                // Debug.Log("fading to: " + scenename);
                // fadeManager.gameObject.SetActive(true);
                // fadeManager.FadeSceneOut(scenename);
                SceneManager.LoadScene(scenename);
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

    public string GetSceneName()
    {
        return scenename;
    }
}
