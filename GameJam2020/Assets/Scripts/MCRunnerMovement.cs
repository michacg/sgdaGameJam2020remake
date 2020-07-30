using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCRunnerMovement : MonoBehaviour
{
    [SerializeField] float TargetYInc;
    [SerializeField] float TotalJumpTime;

    BoxCollider2D box;

    bool isJumping = false;
    bool HoldingSpace = false;
    bool isPlaying = false;

    float OrigY;
    Vector3 TargetPos;

    float timer;

    private void Awake()
    {
        box = this.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        OrigY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            CheckJump();
            CheckCollision();
        }
    }

    void CheckJump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(!isJumping)
            {
                TargetPos = new Vector3(this.transform.position.x, OrigY + TargetYInc, this.transform.position.z);
                timer = 0f;
                StartJumping();
            }

            HoldingSpace = true;
            audioManager.instance.Play("jumping");
        }
        else
        {
            if(HoldingSpace && TargetPos.y != OrigY)
            {
                TargetPos = new Vector3(this.transform.position.x, OrigY, this.transform.position.z);
                timer = 0f;
            }

            HoldingSpace = false;

        }
    }

    void StartJumping()
    {
        if(!isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }


    IEnumerator JumpRoutine()
    {
        isJumping = true;
        while(Mathf.Abs(this.transform.position.y - TargetPos.y) > 0.05f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, TargetPos, timer / TotalJumpTime);
            yield return null;
            timer += Time.deltaTime;

            if(TargetPos.y == OrigY + TargetYInc && Mathf.Abs(this.transform.position.y - TargetPos.y) < 0.05f)
            {
                TargetPos = new Vector3(this.transform.position.x, OrigY, this.transform.position.z);
                timer = 0f;
            }
        }

        this.transform.position = new Vector3(this.transform.position.x, OrigY, this.transform.position.z);

        isJumping = false;
        
    }


    void CheckCollision()
    {
        Collider2D coll = Physics2D.OverlapBox(box.bounds.center, box.bounds.size, 0f, (1 << LayerMask.NameToLayer("Obstacle")));
        if (coll != null)
        {
            if (this.transform.position.y + box.offset.y - box.bounds.extents.y > coll.gameObject.transform.position.y )
            {
                coll.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void Playing(bool b)
    {
        isPlaying = b;
    }

}
