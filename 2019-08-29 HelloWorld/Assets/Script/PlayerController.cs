using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;

[System.Serializable]
public class Event : UnityEvent<bool> { }

public class PlayerController : NetworkBehaviour
{

    [SerializeField] Event onToggleShared;
    [SerializeField] Event onToggleLocal;
    [SerializeField] Event onToggleRemote;


    GameObject mainCamera;


    void Start()
    {
        mainCamera = Camera.main.gameObject;
        ativarJogador();
    }

    void desativarJogador()
    {
        if (isLocalPlayer) { 
            mainCamera.SetActive(true);
            }

        onToggleShared.Invoke(false);

        if (isLocalPlayer)
            onToggleLocal.Invoke(false);
        else
            onToggleRemote.Invoke(false);
    }

    void ativarJogador()
    {
        if (isLocalPlayer)
        {
            mainCamera.SetActive(false);
        }

        onToggleShared.Invoke(true);

        if (isLocalPlayer)
            onToggleLocal.Invoke(true);
        else
            onToggleRemote.Invoke(true);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }   
    }
}

