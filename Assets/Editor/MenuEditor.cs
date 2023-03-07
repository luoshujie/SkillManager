using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MenuEditor
    {
        [MenuItem("GUI/CreateWindow")]
        public static void CreateWindow()
        {
            Debug.Log("Create Window");
            EditorWindow.GetWindow<TestGuiWindow>();
        }
    }
}
