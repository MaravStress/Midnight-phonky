using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMotoPlayer : MonoBehaviour
{
    
    Controles c;
    public Moto moto;
    public float controlVentaja = 1;
     void Awake() {
         c = new Controles();
        c.Enable();
    }
   
    private void OnDisable() {
        c.Disable();
    }
  
    void Update() {
        if (c == null) return;
        Vector2 co = c.Player.Movimiento.ReadValue<Vector2>();
        if(c.Player.R.IsPressed() || c.Player.L.IsPressed() ) co.y = 1;
        else co.y = 0;
        moto.Muevete(new Vector2(co.x,co.y *controlVentaja  )); //
    }
}
