using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMotoPlayer : MonoBehaviour
{
    
    Controles c;
    public Moto moto;
    public float controlVentaja = 1;
    public MasterGame mg;
    [Header("UI")]

    public GameObject Entrar;
    public CarreraEnLaCalle carrera;

     void Awake() {
         c = new Controles();
        c.Enable();
    }
   
   
  
    void Update() {
        if (c == null) return;
        Vector2 co = c.Player.Movimiento.ReadValue<Vector2>();
        if(c.Player.R.IsPressed() || c.Player.L.IsPressed() ) co.y = 1;
        else co.y = 0;
        moto.Muevete(new Vector2(co.x,co.y *controlVentaja  ));

        if (mg.CarreraActual != null) return;
        if (carrera != null)
        {
            Entrar.gameObject.SetActive(true);
            if (c.Player.Start.IsInProgress())
            {
                mg.z_iniciar_Carrara(carrera.id);
                Entrar.gameObject.SetActive(false);
                carrera = null;
            }
        }
        else {
            Entrar.gameObject.SetActive(false);
        }
        
    }
}
