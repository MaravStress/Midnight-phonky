using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event_Random_Multiple : MonoBehaviour
{
   
    public bool playInStart = true;
    public UnityEvent[] events;
    void Start() {
      if(playInStart)  Ejecutar();
    }
    
    public void Ejecutar()
    {
        events[Random.Range(0,events.Length)].Invoke();
    }
}

#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Random_Multiple))]
    [CanEditMultipleObjects]
    public class Editor_evento_Random_Multiple : Editor
    {
        SerializedProperty playInStart,events;



        void OnEnable()
        {

            
            playInStart = serializedObject.FindProperty("playInStart");
            events = serializedObject.FindProperty("events");
        }
        public override void OnInspectorGUI()
        {

           
            EditorGUILayout.PropertyField(playInStart);
            EditorGUILayout.PropertyField(events);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif
