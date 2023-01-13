using UnityEngine;

public class CarreraEnLaCalle : MonoBehaviour
{
    public int id;
     MasterGame MG;
     ControlMotoPlayer p;
    private void Start() {
        MG = FindObjectOfType<MasterGame>();
        p = FindObjectOfType<ControlMotoPlayer>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
    
        if(!MG.Carreras[id].Desbloqueado && !MG.Carreras[id].soyjefe){
            MG.DesbloqueaCarrera.Invoke();
            MG.Carreras[id].Desbloqueado = true;
            MG.ActualizarMapa();
        }
        
        p.carrera = GetComponent<CarreraEnLaCalle>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        p.carrera = null;
    }
}
