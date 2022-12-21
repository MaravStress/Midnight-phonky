using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCarrera : MonoBehaviour
{
    public MasterGame MG;
    public player[] jugadores;

    public GameObject estacionesFather;
    public Transform[] IniPosiciones;
    estacion[] estaciones;
    
    public float radio;
    [Range(0,1)]
    public float ventaja = 3;

    
    void Start() {
        estaciones = estacionesFather.GetComponentsInChildren<estacion>();
        int i = 0;
        foreach (var item in estaciones)
        {
            item.soy = i;
            i++;
            item.colider = item.GetComponent<SphereCollider>();
            item.master = GetComponent<MasterCarrera>();
            item.colider.radius = radio;
            item.colider.isTrigger = true;
             ;
        }
        
        i = 0;
        foreach (var item in jugadores)
        {
            if (item.IA != null) {
                item.IA.Destino(estaciones[0].transform.position);
            }
            senales(item);
            item.Player.transform.SetPositionAndRotation(IniPosiciones[i].position,IniPosiciones[i].rotation);
            i++;
        }
        InvokeRepeating("posicion",0.5f,0.5f);
    }
    public void posicion(){    
    // ordena por estaciones
            int esDispo = 1;
           
            for (int i = estaciones.Length; i >= 0; i--)
            {
                 bool ubo = false;
                foreach (var item in jugadores)
                {
                    if(item.estaciones == i){
                        item.posicion = esDispo;
                        ubo = true;
                    }

                }
                if(ubo){
                    esDispo ++;
                }
            }
    // ordena por distancia
        foreach (var item in jugadores)
        {
            ordenaxdistacia();
            veloMax(item);
        }
        
    }
    void ordenaxdistacia(){
        foreach (var item in jugadores)
        {
           
            foreach (var item2 in jugadores)
            {
                if(item.posicion == item2.posicion && item.Player != item2.Player ){
                    if(distancia(item) > distancia(item2) || item.estaciones < item2.estaciones ){
//                        Debug.Log(item.ToString());
                        item.posicion ++;

                    }else{
                        item2.posicion++;
                    }
                    
                }
            }
           
        }
    }

    public float distancia(player p){
     return Vector3.Distance(p.Player.transform.position,estaciones[p.estaciones].transform.position) ;
    }
    public void Entro(player p){
        posicion();
        //Debug.Log("entro");
        if(p.estaciones >=  estaciones.Length-1){
            if(p.IA == null){
                MG.termino();
            } 
            return;
        }
        if(Vector3.Distance(p.Player.transform.position,estaciones[p.estaciones].transform.position) < (radio*2)){
                p.estaciones ++;
            if (p.IA != null){
                p.IA.Destino(estaciones[p.estaciones].transform.position);
            }
        }
        
        senales(p);

    }

    public void senales(player p){
        if(p.IA == null){ // senales
            for (int i = 0; i < estaciones.Length; i++)
            {
                if(i < p.estaciones){ // los que esten atras
                       estaciones[i].senal.SetActive(false);
                        estaciones[i].flecha.SetActive(false);
                }
                else if(i == p.estaciones){ // El punto
                    estaciones[i].senal.SetActive(true);
                    if(i < estaciones.Length-1){
                        estaciones[i].flecha.SetActive(true);
                        estaciones[i].flecha.gameObject.transform.LookAt(estaciones[i+1].gameObject.transform);

                    }
                }
                else if(i+1 == p.estaciones){ // es siguiente
                    estaciones[i].senal.SetActive(true);
                    estaciones[i].flecha.SetActive(false);

                }else{ // los que vienen
                    estaciones[i].senal.SetActive(false);
                    estaciones[i].flecha.SetActive(false);
                }
            }
        }
    }
    public void veloMax(player p){
        float x = (p.posicion); // (jugadores.Length+1)  * ventaja
        float v  = x/5f; // regla de 3
        
        float vv = 1 - v;
        if (p.IA != null)  p.IA.speed = 1 - (vv * ventaja) ;
    }
    
}
[System.Serializable]
    public class player{
        public GameObject Player;
        public int estaciones;
        public IA_ControlMoto IA;
        public int posicion;
    }