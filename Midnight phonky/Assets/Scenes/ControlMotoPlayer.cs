using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMotoPlayer : MonoBehaviour
{
    
    Controles c;
    public Moto moto;
     void Awake() {
         c = new Controles();
        c.Enable();
    }
    void Update() {
        moto.Muevete(c.Player.Movimiento.ReadValue<Vector2>());
    }
}
