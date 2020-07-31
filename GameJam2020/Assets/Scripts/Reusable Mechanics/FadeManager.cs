using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//manage fading in/out of scenes
public class FadeManager : MonoBehaviour
{
    public FadeManager instance = null;
    private Animator animator;
    [SerializeField] private  AnimationClip FadeIn;

    void Awake(){
         animator = GetComponent<Animator>();
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       animator.Play("FadeOUT"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeSceneOut(string scenename){
        Debug.Log("fading to: " + scenename);
        AnimationEvent evt = new AnimationEvent();
        evt.stringParameter = scenename;
        evt.time = 0.57f;
        evt.functionName = "LoadScene";
        FadeIn.AddEvent(evt);
        
        animator.Play("FadeIN");
    }
    public void LoadScene(string scenename){
        SceneManager.LoadScene(scenename);
    }
    public void SetInactive(){
        this.gameObject.SetActive(false);
    }
    
    public void SetActive(){
        this.gameObject.SetActive(true);
    }
}
