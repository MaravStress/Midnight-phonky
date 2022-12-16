using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_ControlMoto : MonoBehaviour
{
    public Moto moto;
    public NavMeshAgent nav;

    public float rangoMax = 3,rotacion = 4f;
    public Vector3 move;
    public void Destino(Vector3 punto) {
        nav.SetDestination(punto);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, nav.transform.position) > rangoMax)
            nav.transform.position = transform.position;
        
        //move = new Vector3(Mathf.Atan2(nav.transform.forward.x, nav.transform.forward.z) * Mathf.Rad2Deg,0,1 * rotacion).normalized/rotacion;
        //move.y = 0;
       // transform.rotation = nav.transform.rotation;
        moto.Muevete(new Vector2(0, 0.4f));
    }
}
