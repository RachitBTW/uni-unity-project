using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;

    public Animator anim;

    [SerializeField] float speed = 1.5f;
    [SerializeField] float stepWait = 0.5f;

    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("WalkRight");
                StartCoroutine(MoveRight(stepWait));
            }
            else
            {
                anim.Play("WalkLeft");
                StartCoroutine(MoveLeft(stepWait));
            }
        }
        else
        {
            anim.Play("Idle");
        }

        IEnumerator MoveRight(float seconds)
        {
            leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        }

        IEnumerator MoveLeft(float seconds)
        {
            rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        }
    }
}