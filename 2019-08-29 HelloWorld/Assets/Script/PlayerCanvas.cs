using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{

    public static PlayerCanvas canvas;

    [SerializeField] Text valorVida;

    void Start()
    {
        SetVida(100);
    }

    void Awake()
    {
        if (canvas == null)
            canvas = this;
        else if (canvas != this)
            return;
    }

    public void SetVida(int amount)
    {
        valorVida.text = amount.ToString();
    }
}
