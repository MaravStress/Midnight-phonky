using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Moto : MonoBehaviour
{
    Controles c;
   public  Rigidbody rg;
    [Header("suspencion")]
    public float fuerza;
    public float distancia;
    public LayerMask CapaDeSuspencion;
    public Vector2 offset;
    [Header("Fisicas")]
    public Vector3 centro_de_gravedad;
    public float drag;

    [Header("Movimiento")]
    public float acceleracion = 10;
    public float VelocidadMax;
    public float Reversa = 10;

    [Header("Giro")]
    public float Giro = 1;
    [Header("Gamefeel")]
    public int rango_normal = 60;
    public int rango_accelerado = 80;
    public CinemachineVirtualCamera camara;
    private void Awake() {
        c = new Controles();
        c.Enable();
        rg.centerOfMass = centro_de_gravedad;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + centro_de_gravedad,0.1f);
        Gizmos.color = Color.blue;

        Vector3 ori = Origen(offset);
       
        Gizmos.DrawRay(ori,-transform.up * distancia);
        Gizmos.DrawWireSphere(FuerzaAngular(offset,false),0.2f);
        
        ori = Origen(new Vector2(-offset.x,offset.y)); 
        
        Gizmos.DrawRay(ori,-transform.up * distancia);
        Gizmos.DrawWireSphere(FuerzaAngular(new Vector2(-offset.x,offset.y),false),0.2f);

    }
    private void Update() {
        Vector3 v = rg.velocity;
            v.y = 0;
            camara.m_Lens.FieldOfView = rango_normal+(v.magnitude* (rango_accelerado-rango_normal)) /VelocidadMax;
    }
    private void FixedUpdate() {
        Vector2 m = c.Player.Movimiento.ReadValue<Vector2>(); // controles
    // rotacion
    transform.Rotate(new Vector3(0,m.x,0) * Giro ); // giro
            
    // suspencion
        Vector3 f1,f2;
        f1 = FuerzaAngular(offset,true); // goma de alante
        f2 = FuerzaAngular(new Vector2(-offset.x,offset.y),true); // goma de atras
    // esta en el aire
        bool aire = (f2 == Vector3.zero); 
        
    // reajustes
    if(f1 != Vector3.zero && aire){
        rg.centerOfMass = Vector3.zero;
    }else{
        rg.centerOfMass = centro_de_gravedad;
    }

        
    
    // Motor
    if(aire){
        rg.drag = 0;
        return;
    }else{
        rg.drag = drag;
    } 

        if(m.y > 0){
            Vector3 v = rg.velocity;
            v.y = 0;
            if(v.magnitude < VelocidadMax)
            rg.AddForce(transform.forward * m.y * acceleracion,ForceMode.Acceleration); // Acceleracion y retroceso
        }else
            rg.AddForce(transform.forward * m.y * Reversa,ForceMode.Acceleration);

    
    
    
    
    
    }

    Vector3 Origen(Vector2 _offset){
        return transform.position + (transform.forward *  _offset.x) + (transform.up *  _offset.y);
    }
    Vector3 FuerzaAngular(Vector2 _offset,bool aplicar){
        RaycastHit hit;
        Physics.Raycast(Origen(_offset),-transform.up, out hit, distancia,CapaDeSuspencion);  
        if(hit.point != Vector3.zero){
            float distanciaReal = Vector3.Distance(Origen(_offset),hit.point);
            if(distanciaReal < distancia){
               // rg.AddForce(Vector3.up * fuerza *(distancia - distanciaReal),ForceMode.Force); // fuerza
               //rg.AddTorque(new Vector3(-_offset.x * (distancia - distanciaReal)*Angulo,0,0),ForceMode.Force); // rotacion
                if(aplicar)
                rg.AddForceAtPosition(hit.normal* fuerza * (distancia - distanciaReal)  , Origen(_offset),ForceMode.Impulse);
            }
        }

        return hit.point;
    }
    
}
