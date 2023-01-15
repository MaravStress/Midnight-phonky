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
    [Header("Sonido")]
    public float fadeTimeAcelera = 0.3f;
    public float fadeTimeDesacelera = 1f,rangoFuerzaimpacto = 15;
    float ft;
    public  AudioSource idel,run,coque;
    public AudioClip[] choqueVersiones;
    
     void Awake() {
         c = new Controles();
        c.Enable();
    }
   
   
  bool corre;
    void Update() {
        if (c == null) return;
        Vector2 co = c.Player.Movimiento.ReadValue<Vector2>();
        if(c.Player.R.IsPressed() || c.Player.L.IsPressed() ){co.y = 1;
       corre = true;
        }else{
            co.y = 0;
             corre = false;
        } 
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
        // sonido ///////////////////////////////////

        idel.volume = 1 - ft;
        run.volume = ft;
        
        if(corre){
            if(ft<1) ft += Time.deltaTime * fadeTimeAcelera;
        }else{
            if(ft>0) ft -= Time.deltaTime * fadeTimeDesacelera;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.relativeVelocity.magnitude < rangoFuerzaimpacto) return;
        coque.PlayOneShot(choqueVersiones[Random.Range(0,choqueVersiones.Length)]);
    }
}
