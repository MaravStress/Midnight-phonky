using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Event_Time : MonoBehaviour
{
    public float time = 2;
     float t;
    public bool isActive,loop;
    public UnityEvent action;

    private void Start()
    {
        if (isActive && (time == 0 || time <= 0)) {
            action.Invoke();
        }
        t = time;
    }
    void Update()
    {
        if (isActive) {
            if (t> 0)
            {
                t -= Time.deltaTime;
            }
            else {
                action.Invoke();
                isActive = false;
                if (loop)
                    z_Active();
                
            }
        }
    }
    public void z_Active() {
        if(isActive == false){
            isActive = true;
            Start();
        }
        
    }

    public void z_Reboot()
    {
        Start();
    }

}





#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(Event_Time))]
    [CanEditMultipleObjects]
    public class Editor_Evento_Time : Editor
    {
  

        SerializedProperty tiempo, isActive, loop, Action;

        void OnEnable()
        {

            Action = serializedObject.FindProperty("action");
            loop = serializedObject.FindProperty("loop");
            isActive = serializedObject.FindProperty("isActive");
            tiempo = serializedObject.FindProperty("time");

        }
        public override void OnInspectorGUI()
        {
        
            EditorGUILayout.PropertyField(tiempo);
            EditorGUILayout.PropertyField(isActive);
            EditorGUILayout.PropertyField(loop);


            EditorGUILayout.PropertyField(Action);

            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Space(40);
        }



    }
}


#endif
