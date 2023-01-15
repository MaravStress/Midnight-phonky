using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour 
{ 
    public string[] scene;
    public void z_Simple(int i)
    {
        SceneManager.LoadScene(scene[i], LoadSceneMode.Single);
    }
    public void z_Add(int i)
    {
        SceneManager.LoadScene(scene[i], LoadSceneMode.Additive);
    }
    public void z_Remove(int i)
    {
        SceneManager.UnloadSceneAsync(scene[i]);
    }
}
#if UNITY_EDITOR
namespace UnityEditor
{
    [CustomEditor(typeof(changeScene))]
    [CanEditMultipleObjects]
    public class Editor_Evento_Scene : Editor
    {
        SerializedProperty scene;
        void OnEnable()
        {
            scene = serializedObject.FindProperty("scene");
        }
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(scene);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
