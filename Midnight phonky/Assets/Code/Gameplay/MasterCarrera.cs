using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCarrera : MonoBehaviour
{
    public MasterGame MG;
    public List<player> jugadores;

    public GameObject estacionesFather;
    public Transform[] IniPosiciones;
    public estacion[] estaciones;
    public int competidores_count = 4;
    [Header("conversacion")]
     Conversacion conversacion;
    public bool conversacionStart;
    public int idConversacionStart;
    public bool conversacionEndWin;
    public int idConversacionEndWin;
    public bool conversacionEndLoser;
    public int idConversacionEndLoser;
    [Header("Soy jefe")]
    public bool jefe;
    public int id_jefe;

    public float radio;


    void iniciacion() {
        foreach (var item in MG.jugadores)
        {
            item.Player.SetActive(false);
        }
        if (jefe)
        {
            MG.jugadores[0].Player.SetActive(true);
            MG.jugadores[id_jefe].Player.SetActive(true);
            jugadores.Add(MG.jugadores[0]);
            jugadores.Add(MG.jugadores[id_jefe]);
        }
        else {
            for (int i = 0; i < competidores_count; i++)
            {
                MG.jugadores[i].Player.SetActive(true);
                jugadores.Add(MG.jugadores[i]);
            }
        }
        
                
    }
    void Start() {
        iniciacion();

        estaciones = estacionesFather.GetComponentsInChildren<estacion>();

        for (int i = 0; i < estaciones.Length; i++)
        {
            estacion item = estaciones[i];
            item.soy = i;
            item.colider = item.GetComponent<SphereCollider>();
            item.master = GetComponent<MasterCarrera>();
            item.colider.radius = radio;
            item.colider.isTrigger = true;
        }
        
        
        for (int i = 0; i < jugadores.Count; i++)
        {
            if (jugadores[i].IA != null) {
                jugadores[i].IA.Destino(estaciones[0].transform.position);
            }
            
            jugadores[i].Player.transform.SetPositionAndRotation(IniPosiciones[i].localPosition,IniPosiciones[i].localRotation);
           
        }
        
        InvokeRepeating("posicion",0.5f,0.5f);
        senales();
        conversacion = FindObjectOfType<Conversacion>();
        if(conversacionStart) conversacion.Z_ShowPredefinidas(idConversacionStart);
    }
    private void LateUpdate()
    {
        MG.brujula.Ir(estaciones[MG.jugadores[0].estaciones].transform);
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
            Ventaja(item);
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
        if(p.estaciones >=  estaciones.Length-1){ // termino la carrera
            if(p.IA == null){
                if(p.posicion == 1)
                    if(conversacionEndWin) conversacion.Z_ShowPredefinidas(idConversacionEndWin);
                else
                    if(conversacionEndLoser) conversacion.Z_ShowPredefinidas(idConversacionEndLoser);
                MG.termino();
            } 
            return;
        }
        if(Vector3.Distance(p.Player.transform.position,estaciones[p.estaciones].transform.position) < (radio*2)){
                p.estaciones ++;
            if (p.IA != null){
                p.IA.Destino(estaciones[p.estaciones].transform.localPosition);
                p.ir = estaciones[p.estaciones].transform;
              //  Debug.Log("pra");
            }
        }
        
        senales();

    }

    public void senales(){
        player p = MG.jugadores[0];
        
            for (int i = 0; i < estaciones.Length; i++) //  esto esta para el carajo
            {
                if(i > p.estaciones){ // los que esten atras
                       estaciones[i].senal.SetActive(false);
                        estaciones[i].flecha.SetActive(false);
                }
                if(i == p.estaciones){ // El punto
                    estaciones[i].senal.SetActive(true);
                    if(i < estaciones.Length-1){
                        estaciones[i].flecha.SetActive(true);
                        estaciones[i].flecha.gameObject.transform.LookAt(estaciones[i+1].gameObject.transform);

                    }
                }
                if(i+1 == p.estaciones){ // es siguiente
                    estaciones[i].senal.SetActive(true);
                    estaciones[i].flecha.SetActive(false);
                }
                if(i < p.estaciones){ // los que vienen
                    estaciones[i].senal.SetActive(false);
                    estaciones[i].flecha.SetActive(false);
                }
            }
        
    }
    public void Ventaja(player p){
        // float x = (p.posicion); // (jugadores.Length+1)  * ventaja
        // float v  = x/5f; // regla de 3
        
        // float vv = 1 - v;
        // float formula = 1 - (vv * ventaja);
        float formula = 1 - ((1 - ( p.posicion/5f)) * MG.ventaja);

        if (p.IA != null)  p.IA.speed =  formula;
        else p.Player.GetComponent<ControlMotoPlayer>().controlVentaja = formula;
    }
    
}
