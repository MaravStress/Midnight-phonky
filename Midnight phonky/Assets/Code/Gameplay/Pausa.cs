using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pausa : MonoBehaviour
{
    public GameObject PanelPausa;
    [Header("Sonido")]
    public AudioMixer Master;
    public AudioMixerSnapshot play,pausa;
    [Header("Radio")]
    public AudioSource bgMusica;
    public int RadioActual;
    public List<AudioClip> cola;
    
    public radio[] Radios;
    [System.Serializable]
    public class radio{
 
        public AudioClip[] Canciones;
    }

    private void Start() {
        QuitarPausa();
        InvokeRepeating("Update_cancion",2,2);
    }
    public void Pausar(){
        Time.timeScale = 0;
        PanelPausa.SetActive(true);
        pausa.TransitionTo(0.3f);
        
    }
    public void QuitarPausa(){
        Time.timeScale = 1;
        PanelPausa.SetActive(false);
        play.TransitionTo(0.3f);
    }
 
    public void Volumen_SFX(float v){ 
        Master.SetFloat("Volumen_SFX",calculo(v));
    }
    public void Volumen_Musica(float v){ 
        Master.SetFloat("Volumen_Musica",calculo(v));
    }
    public void Volumen_Master(float v){ 
        Master.SetFloat("Master",calculo(v));
    }
   float calculo(float v){
            float c = Mathf.Log10(v)* 30;
            if(c > -80){
                return c;
            }else{
                return -80;
            }
    }

    public void Cambio_radio(int i){
        RadioActual = i; // cambiamos la radio
        cola.Clear(); // limpiamos la cola
        foreach (var item in Radios[i].Canciones) // cargamos la cola
        {
            cola.Add(item);
        }
        Update_cancion(); // actualizamos
    }
    
    void Update_cancion(){
        if(!bgMusica.isPlaying ){
            if(cola.Count > 0){
                AudioClip clip = cola[0];
                bgMusica.PlayOneShot(clip);
                cola.Remove(clip);
            }else
            {
                Cambio_radio(RadioActual);
            }
        }
        
    }
    
    

}
