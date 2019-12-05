using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCanvas : MonoBehaviour
{

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        try
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    objectHit.GetComponentInChildren<Canvas>().enabled = !objectHit.GetComponentInChildren<Canvas>().isActiveAndEnabled;
                }
            }
        }catch (Exception e)
        {

        }
        
    }
}
