using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Start_Idioma : MonoBehaviour
{

    public Idioma idioma;
  
    void Awake()
    {
        idioma.cargarTraduccion(idioma.traduccionActual);
        Debug.Log("traducciones cargadas del obj: "+name+" El archivo:"+idioma.traduccionActual);
    }
    
}
