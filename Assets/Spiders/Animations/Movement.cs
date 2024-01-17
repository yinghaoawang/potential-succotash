using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Camera camera;
    public SpiderController player;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        drawDebug();
        
        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;

            if (Physics.Raycast(camera.ScreenPointToRay(mousePos), out hit, Mathf.Infinity)) {
                player.SetTarget(hit.point);
            }
        }

    }

    void drawDebug() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(camera.transform.position, mousePos - camera.transform.position, Color.blue);
    }
}
