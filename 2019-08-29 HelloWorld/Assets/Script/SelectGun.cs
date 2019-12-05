using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelectGun : NetworkBehaviour {

    [SerializeField] Transform armaSpawn;

    public GameObject armaAtual;

    public GameObject akPrefab;
    public GameObject pistolaPrefab;
    public GameObject shotgunPrefab;
    public GameObject uziPrefab;


    // Use this for initialization
    void Start () {
        akPrefab.transform.position = armaSpawn.position;
        akPrefab.transform.rotation = armaSpawn.rotation;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            akPrefab.transform.position = Vector3.zero;
               
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            akPrefab.transform.position = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            akPrefab.transform.position = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            akPrefab.transform.position = Vector3.zero;
        }
    }

	}

