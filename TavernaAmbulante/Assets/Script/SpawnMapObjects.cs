using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMapObjects : MonoBehaviour
{
    private Camera cam;

    private bool destroybool;

    public GameObject tree;
    private bool treeBool = false;

    public GameObject house;
    private bool houseBool = false;

    public GameObject barn;
    private bool barnBool = false;

    public GameObject fence;
    private bool fenceDownBool = false, fenceTopBool = false, fenceLeftBool = false, fenceRightBool = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    Instantiate(tree, objectHit.transform.position, new Quaternion(0, Random.value * 360, 0, 1));
                }
                treeBool = false;
            }
        }

        if (houseBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    Instantiate(house, objectHit.transform.position, house.transform.rotation);
                }
                houseBool = false;
            }
        }

        if (barnBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    Instantiate(barn, objectHit.transform.position, barn.transform.rotation);
                }
                barnBool = false;
            }
        }

        if (fenceDownBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    Instantiate(fence, objectHit.transform.position - new Vector3(0,0, 3.63f), barn.transform.rotation);
                }
                fenceDownBool = false;
            }
        }

        if (fenceTopBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    Instantiate(fence, objectHit.transform.position + new Vector3(0, 0, 3.63f), barn.transform.rotation);
                }
                fenceTopBool = false;
            }
        }

        if (fenceLeftBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    Instantiate(fence, objectHit.transform.position + new Vector3(0, 0, 3.63f), new Quaternion(0,90,0,1));
                }
                fenceLeftBool = false;
            }
        }

        if (fenceRightBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    Instantiate(fence, objectHit.transform.position + new Vector3(0, 0, 3.63f), new Quaternion(0, -90, 0, 1));
                }
                fenceRightBool = false;
            }
        }

        if (destroybool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (objectHit.CompareTag("Object"))
                    {
                        Destroy(objectHit.gameObject);
                    }
                }
                destroybool = false;
            }
        }
    }

    public void SpawnTree()
    {
        treeBool = true;
    }

    public void SpawnHouse()
    {
        houseBool = true;
    }

    public void SpawnBarn()
    {
        barnBool = true;
    }

    public void FenceDown()
    {
        fenceDownBool = true;
    }

    public void FenceTop()
    {
        fenceTopBool = true;
    }

    public void FenceLeft()
    {
        fenceLeftBool = true;
    }

    public void FenceRight()
    {
        fenceRightBool = true;
    }

    public void DestroyObject()
    {
        destroybool = true;
    }
}
