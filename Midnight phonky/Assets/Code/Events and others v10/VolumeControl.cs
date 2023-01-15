using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerGroup grupo;
    public void ZZ_setVolume(float i){
        
        float desivelios = 20 * Mathf.Log10(i);
       
        mixer.SetFloat(grupo.name,desivelios);
         Debug.Log("El volumen de "+grupo.name+" es de: "+ desivelios.ToString());
      //  float a;
        //mixer.GetFloat(grupo.name,out a);
       // Debug.Log(a.ToString());
    }
}
