using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerObstacle : MonoBehaviour
{
    [SerializeField] float LeftBound;
    [SerializeField] float RightBound;
    [SerializeField] float Speed;
    [SerializeField] float SpeedInc;

    BoxCollider2D box;
    SpriteRenderer sprite;

    float halfWidth;

    bool isPlaying = false;

    private void Awake()
    {
        box = this.GetComponent<BoxCollider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        halfWidth = box.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
            MoveAcrossScreen();
    }

    void MoveAcrossScreen()
    {
        if(this.transform.position.x <= LeftBound + halfWidth && sprite.enabled)
        {
            sprite.enabled = false;
        }

        if (this.transform.position.x <= LeftBound - halfWidth)
        {
            this.transform.position = new Vector3(RightBound + halfWidth, this.transform.position.y, this.transform.position.z);
            sprite.enabled = true;
        }

        this.transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        Speed += SpeedInc;
    }

    public void Playing(bool b)
    {
        isPlaying = b;
    }
}
