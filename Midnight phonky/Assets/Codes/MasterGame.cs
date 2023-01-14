using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MasterGame : MonoBehaviour
{

    public GameObject CarreraActual;
    public Brujula brujula;
    [Header("Carreras")]
    public player[] jugadores;
    public carrera[] Carreras;


    [Header("Cosas dentro de carrea")]
    public int contador = 3;
    public int Esta_es_la_carrera = -1;
    public bool contando;
    [Range(0,1)]
    public float ventaja = 3;
     [Header("Eventos")]
    public UnityEvent DesbloqueaCarrera;
    public UnityEvent UnJefeTeEspera;
    private void Start()
    {
        brujula.dejarDeIr();
        Load();
        ActualizarMapa();
    }
    public void z_ir_carrera(int i) {
        brujula.Ir(Carreras[i].puerta.transform);
    }
    public void z_Salir_De_Carrera(){
        
        foreach (var item in Carreras)
        {
            item.puerta.SetActive(true);
        }
        Destroy(CarreraActual);
        foreach (var item in jugadores)
        {
            item.estaciones  = 0;
            item.posicion = 0;
        }
        brujula.dejarDeIr();
        ActualizarMapa();
    }
    public void termino(){
        if (jugadores[0].posicion == 1)
        {
            Carreras[Esta_es_la_carrera].gane = true;
        }
        z_Salir_De_Carrera();
        
    }
    public void z_Reinicio_de_carrera(){
        z_Salir_De_Carrera();
        Invoke("rc",0.1f);
    }
    void rc(){
        z_iniciar_Carrara(Esta_es_la_carrera);
    }
    public void z_iniciar_Carrara(int i){
        Esta_es_la_carrera = i;
        if(CarreraActual != null){
            Debug.LogError("Ya hay una carrera activa, esto no deberia de salir. Doble click para llorar");
            return;
        } 
        CarreraActual = Instantiate(Carreras[i].Carrera,Vector3.zero,Quaternion.Euler(0,0,0));
        MasterCarrera mc = CarreraActual.GetComponent<MasterCarrera>();
        mc.MG = this.gameObject.GetComponent<MasterGame>(); 

        contando = true;
        Invoke("inicio",contador);
        foreach (var item in Carreras)
        {
            item.puerta.SetActive(false);
        }
    }
    private void Update() {
        if(!contando) return;

        foreach (var item in jugadores)
        {
            Moto m = item.Player.GetComponent<Moto>(); 
            m.activo = false;
            m.rg.velocity = new Vector3(0,m.rg.velocity.y,0);
            m.rg.rotation = Quaternion.Euler(0,0,0);
            MasterCarrera c = CarreraActual.GetComponent<MasterCarrera>();
            if(c.estaciones.Length>0)m.transform.LookAt(c.estaciones[0].gameObject.transform.position);
            
        }
    

    }
    void inicio(){
        contando = false;
        foreach (var item in jugadores)
        {
            item.Player.GetComponent<Moto>().activo = true;
        }
       
    }

    public void ActualizarMapa(){
        Carreras[0].Desbloqueado = true; // la carrera 1 siempre esta disponible

        bool superado = true;
        foreach (var item in Carreras)  
        {
            // Desactivamos las que no estan activas 
            if(item.Desbloqueado){  
                item.PuntoEnMapa.SetActive(true);
            }else{
                item.PuntoEnMapa.SetActive(false);
            }
            // Activamos o desactivamos al jefe
            if(!item.gane && item.soyjefe == false) superado = false; //solo verifica las carreras, los jefes no

            if(item.soyjefe){
                 item.PuntoEnMapa.SetActive(superado);
                 item.puerta.SetActive(superado);
                 item.Desbloqueado = superado;
            }
        }
        
    }

    public void Save(){
        
    }
    public void Load(){
        
    }
}
[System.Serializable]
    public class player{
        public GameObject Player;
        public int estaciones;
        public IA_ControlMoto IA;
        public Transform ir;
        public int posicion;
    }

[System.Serializable]
public class carrera
{
    public string ZonaYTipo;
    public bool soyjefe;
    public GameObject Carrera;
    public GameObject PuntoEnMapa;
    public GameObject puerta;
    public bool gane;
    public bool Desbloqueado;
   
}
