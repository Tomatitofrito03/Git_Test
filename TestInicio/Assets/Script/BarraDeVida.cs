using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;

    public void SetVida(int vida)
    {
        slider.value = vida;
    }
}
