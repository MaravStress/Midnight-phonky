using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarreraEnLaCalle : MonoBehaviour
{
    public UnityEvent entrar;
    Controles c;
    public Moto moto;
    public float controlVentaja = 1;
    void Awake()
    {
        c = new Controles();
        c.Enable();
    }

    private void OnDisable()
    {
        c.Disable();
    }
}
