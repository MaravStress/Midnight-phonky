using UnityEngine;

public class CarreraEnLaCalle : MonoBehaviour
{
    public int id;
    public ControlMotoPlayer p;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        p.carrera = GetComponent<CarreraEnLaCalle>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        p.carrera = null;
    }
}
