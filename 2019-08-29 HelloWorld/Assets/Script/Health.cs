using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour
{
    public const int vidaMaxima = 100;

    [SyncVar(hook = "vidaMudou")] public int vidaAtual = vidaMaxima;

    public RectTransform healthBar;

    public void tomouDano(int amount)
    {
        if (!isServer)
            return;

        vidaAtual -= amount;
        if (vidaAtual <= 0)
        {
            vidaAtual = vidaMaxima;
            
            // called on the Server, but invoked on the Clients
            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {

        if (isLocalPlayer)
        {
            Respawn();

        }
    }

    void Respawn()
    {
        if (isLocalPlayer)
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }
    }

    void vidaMudou(int value)
    {
        vidaAtual = value;
        healthBar.sizeDelta = new Vector2(value, healthBar.sizeDelta.y);
        if (isLocalPlayer)
            PlayerCanvas.canvas.SetVida(value);
    }
}

