using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void z_Play(int i)
    {
        audioSource.PlayOneShot(audioClips[i]);
    }
    public void z_Stop()
    {
        audioSource.Stop();
    }
    public void z_Pause(bool i) {
        if (i)
            audioSource.Pause();
        else
            audioSource.UnPause();

    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(Audio))]
[CanEditMultipleObjects]

public class Editor_Audio : Editor
{
    bool desplegado;


    SerializedProperty audioSource, audioClips;
    void OnEnable()
    {
        audioSource = serializedObject.FindProperty("audioSource");
        audioClips = serializedObject.FindProperty("audioClips");
    }
    public override void OnInspectorGUI()
    {
        var p = (Audio)target;
        if (p == null) return;

        EditorGUILayout.PropertyField(audioSource);
        EditorGUILayout.PropertyField(audioClips);
        desplegado = EditorGUILayout.Foldout(desplegado, "Funciones");
        if (desplegado) {
            EditorGUILayout.LabelField("Funcion play", "Play( [int] )");
            EditorGUILayout.TextField("Funcion Stop", "Stop");
            EditorGUILayout.LabelField("Funcion pause", "Pause( [bool] )");
        }
        serializedObject.ApplyModifiedProperties();

    }


}
#endif