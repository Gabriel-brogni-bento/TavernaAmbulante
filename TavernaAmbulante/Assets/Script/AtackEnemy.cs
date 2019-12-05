using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    public Dice dice;
    public AppDemo appDemo;

    public GameObject spawnPoint;



    public float Life;
    public float CombatArmor;
    public float AtackValue;

    private bool atack;
    private Camera cam;

    public GameObject hitted = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (atack)
        {
            if (Input.GetMouseButtonDown(2))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    hitted = objectHit.gameObject;
                    if (dice.getHighValue() >= hitted.GetComponent<AtackEnemy>().CombatArmor)
                    {
                        hitted.GetComponent<AtackEnemy>().Life -= AtackValue + dice.getHighValue();
                        print("Vida do inimigo: " + hitted.GetComponent<AtackEnemy>().Life);
                        if (hitted.GetComponent<AtackEnemy>().Life <= 0)
                        {
                            Destroy(hitted);
                        }
                    }
                    else
                    {
                        print("Combat Armor from oponent is higher");
                    }
                }
                atack = false;
            }
            
        }
    }

    public void atackEnemy()
    {
        atack = true;
    }

    public void atackRoll()
    {
        //StartCoroutine("waitforseconds");
    }

    public IEnumerator waitforseconds()
    {
        yield return new WaitForSecondsRealtime(1f);

        if (dice.getHighValue() >= hitted.GetComponent<AtackEnemy>().CombatArmor)
        {
            hitted.GetComponent<AtackEnemy>().Life -= AtackValue + dice.getHighValue();
            print("Vida do inimigo: " + hitted.GetComponent<AtackEnemy>().Life);
            if (hitted.GetComponent<AtackEnemy>().Life <= 0)
            {
                Destroy(hitted);
            }
        }
        else
        {
            print("Combat Armor from oponent is higher");
        }

        StopCoroutine("waitforseconds");
    }

    public IEnumerator atackWait()
    {
        yield return new WaitForSecondsRealtime(3f);
        hitted.GetComponent<AtackEnemy>().Life -= AtackValue + dice.getHighValue();
        print("Vida do inimigo: " + hitted.GetComponent<AtackEnemy>().Life);
        if(hitted.GetComponent<AtackEnemy>().Life <= 0)
        {
            Destroy(hitted);
        }
        StopCoroutine("atackWait");
    }
}
