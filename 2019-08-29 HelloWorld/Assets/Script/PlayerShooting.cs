using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour {

    [SerializeField] float tiroCooldown = .4f;
    [SerializeField] Transform balaSpawn;
    [SerializeField] Event animacao;

    public GameObject balaPrefab;

    float tempoAtual;
    bool podeAtirar;


    void Start () {
        if (isLocalPlayer)
        {
            podeAtirar = true;
            animacao.Invoke(false);
        }
    }
	
	void Update () {

        if (!podeAtirar)
            return;

        tempoAtual += Time.deltaTime;
        if (Input.GetButton("Fire1") && tempoAtual/1.2 > tiroCooldown)
        {
            animacao.Invoke(true);
            tempoAtual = 0f;
            CmdAtirar(balaSpawn.position, balaSpawn.forward);
        }else if (!Input.GetButton("Fire1"))
        {
            animacao.Invoke(false);
        }
    }


    [Command]
    void CmdAtirar(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;

        // Cria a bala apartir do prefab da Bala
        var bullet = Instantiate(
            balaPrefab,
            balaSpawn.position,
            balaSpawn.rotation);

        // Adiciona velocidade a bala
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;

        // Spawn a bala para todos os clientes
        NetworkServer.Spawn(bullet);

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red, 1f);

        bool result = Physics.Raycast(ray, out hit, 50f);

        if (result)
        {
            Health enemy = hit.transform.GetComponent<Health>();

            if (enemy != null)
                enemy.tomouDano(10);
        }

        // Destroi a bala depois de 2 segundos
        Destroy(bullet, 2.0f);
    }
}
