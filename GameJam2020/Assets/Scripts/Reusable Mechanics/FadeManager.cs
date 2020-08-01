using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//manage fading in/out of scenes
public class FadeManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private  AnimationClip FadeIn;

    void Awake(){
         animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       animator.Play("FadeOUT"); 
        Debug.Log("fade manager events: " +  FadeIn.events.Length);
        if(FadeIn.events.Length > 0){
            Debug.Log(FadeIn.events[0].stringParameter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeSceneOut(string scenename){
       if(FadeIn.events.Length == 0){
        Debug.Log("fading to: " + scenename);
            AnimationEvent evt = CreateSceneTransitionEvent(scenename);
            FadeIn.AddEvent(evt);
       }else{
            AnimationEvent[] animationEvents = new AnimationEvent[]{CreateSceneTransitionEvent(scenename)};
            //FadeIn.events[0].stringParameter=scenename;
            FadeIn.events = animationEvents;
       }
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
    private AnimationEvent CreateSceneTransitionEvent(string scenename){
        AnimationEvent evt = new AnimationEvent();
        evt.stringParameter = scenename;
        evt.time = 0.57f;
        evt.functionName = "LoadScene";
        return evt;
        
    }
}
