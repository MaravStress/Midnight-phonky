using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link_web : MonoBehaviour
{
    public string[] link;
    
    public void Abrir(int i) { 
        Application.OpenURL(link[i]); 
    }
    public void Abrir_Personalizado(string i)
    {
        Application.OpenURL(i);
    }
}
