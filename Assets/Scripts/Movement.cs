using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private AudioSource moveSound;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private CircleCollider2D leftCollider;
    [SerializeField] private CircleCollider2D rightCollider;
    [SerializeField] private TrailRenderer trailLeft;
    [SerializeField] private TrailRenderer trailRight;
    public GameObject leftSquare;
    public GameObject rightSquare;

    private void Awake()
    {
        trailLeft.emitting = false;
        trailRight.emitting = false;
        StartCoroutine(StartTrail());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            moveSound.Play();
            if (rotation.z < 0)
            {
                PivotTo(leftSquare.transform.position);
                rotation = -rotation;
                leftCollider.enabled = true;
                rightCollider.enabled = false;
            }
            else if (rotation.z > 0)
            {
                PivotTo(rightSquare.transform.position);
                rotation = -rotation;
                leftCollider.enabled = false;
                rightCollider.enabled = true;
            }
        }
        transform.Rotate(rotation * Time.deltaTime);
    }
    public void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach (Transform child in transform)
            child.transform.position += offset;
        transform.position = position;
    }

    IEnumerator StartTrail()
    {
        yield return new WaitForSeconds(0.25f);
        trailLeft.emitting = true;
        trailRight.emitting = true;
    }
}
