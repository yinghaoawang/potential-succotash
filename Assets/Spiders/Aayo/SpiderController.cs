using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public bool hasTarget = false;
    public Vector3 target;
    Animator animator;
    public float speed = 5.0f;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Quaternion lookAtRotation = Quaternion.LookRotation(transform.position - target);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, rotationSpeed * Time.deltaTime);
            animator.Play("Walk");

            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                hasTarget = false;
                target = Vector3.zero;
                animator.Play("Idle");
            }
        }
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        this.hasTarget = true;
    }
}
