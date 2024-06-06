using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutter: MonoBehaviour
{
    CircleCollider2D cutter;
    private bool cutting;
    private Camera cam;
    private TrailRenderer bladetrail;
    Rigidbody2D rb;
    public AudioSource cutsound;
    public Vector3 direction { get; private set; }
    public float mincutvelocity = 0.01f;
    private void Awake()
    {
        cam = Camera.main;
        cutter = GetComponent<CircleCollider2D>();
        bladetrail = GetComponentInChildren<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDisable()
    {
        stopCutting();
    }
    private void OnEnable()
    {
        stopCutting();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopCutting();
        }
        else if (cutting)
        {
            continueCutting();
        }
    }

    private void startCutting()
    {
        Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;
        cutter.enabled = false;
        cutting = true;
        bladetrail.enabled = true;
        bladetrail.Clear();
    }
    private void stopCutting()
    {
        cutter.enabled = false;
        cutting = false;
        bladetrail.enabled = false;
    }
    private void continueCutting()
    {
        Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        if(velocity > mincutvelocity)
        {
            cutter.enabled = true;
        }
        else
        {
            cutter.enabled = false;
        }
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Rope")
        {
            cutsound.Play();
            Destroy(collider.gameObject);           
        }
    }
}