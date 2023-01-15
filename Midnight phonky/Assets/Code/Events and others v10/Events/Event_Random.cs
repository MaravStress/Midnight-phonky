using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Random : MonoBehaviour
{
    [Range(1,100)]
        public int possibility = 50;
    public bool playInStart = true;
    public Button.ButtonClickedEvent  yes,no;
    private void Start() {
      if(playInStart)  Ejecutar();
    }
    public void ChancePossibility(int i)
    {
        possibility = i;
    }
    public void Ejecutar()
    {
        if(Random.Range(0,100) <= possibility)
        yes.Invoke();
        else
        no.Invoke();
    }
}

#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Random))]
    [CanEditMultipleObjects]
    public class Editor_evento_Random : Editor
    {
        SerializedProperty playInStart,possibility,yes,no;



        void OnEnable()
        {

            yes = serializedObject.FindProperty("yes");
            no = serializedObject.FindProperty("no");
            possibility = serializedObject.FindProperty("possibility");
            playInStart = serializedObject.FindProperty("playInStart");
        }
        public override void OnInspectorGUI()
        {

            EditorGUILayout.PropertyField(possibility);
            EditorGUILayout.PropertyField(playInStart);
            EditorGUILayout.PropertyField(yes);
            EditorGUILayout.PropertyField(no);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif
