using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public SpiderController player;

    // Update is called once per frame
    void Update()
    {
        drawDebug();
        
        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit, Mathf.Infinity)) {
                player.SetTarget(hit.point);
            }
        }

    }

    void drawDebug() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(Camera.main.transform.position, mousePos - Camera.main.transform.position, Color.blue);
    }

}
