using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text valor;
    public int valorInicial;
    // Start is called before the first frame update
    void Start()
    {
        CuentaAtras();
    }

    // Update is called once per frame
    IEnumerator CuentaAtras()
    {
        if(valorInicial > 0)
        {
            valor.text = valorInicial.ToString();
            yield return new WaitForSeconds(1);
            reiniciar();
        }
    }

    void reiniciar()
    {
        CuentaAtras();
    }
}
