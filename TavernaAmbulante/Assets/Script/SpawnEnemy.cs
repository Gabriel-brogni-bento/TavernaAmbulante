using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject Enemy1;

    public GameObject canvas;

    private bool Enemy1Bool = false;


    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Enemy1Bool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    Instantiate(Enemy1, objectHit.transform.position, Enemy1.transform.rotation);
                }
                Enemy1Bool = false;
            }

        }
    }

    public void spawnEnemy1()
    {
        Enemy1Bool = true;
    }

    public void cancel()
    {
        Enemy1Bool = false;
        canvas.SetActive(false);
    }
}
