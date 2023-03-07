using System;
using UnityEditor;
using UnityEngine;

public class TestGuiWindow : EditorWindow
{
    public string bugName = "";
    public string reportTime = "";
    public string desc = "";
    public float progress = 0;
    public int titleToolBar = 0;
    public GameObject selectObg;
    public Color selectColor;
    public string selectTag;
    public bool onlyToggle;
    public int popup;
    public Texture texture;


    private string[] TitleToolBarSelectStringList = new[] {"窗口1","窗口2","窗口3","其他"};
    private string[] PopupTitleSelectStringList = new[] {"选项1", "选项2", "选项3"};
    TestGuiWindow()
    {
        this.titleContent = new GUIContent("TestGuiWindow");
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        titleToolBar = GUILayout.Toolbar(titleToolBar,TitleToolBarSelectStringList);
        GUILayout.Space(20);
        GUILayout.EndVertical();
        
        if (titleToolBar == 0)
        {
            GUILayout.BeginVertical();
            GUI.skin.label.fontSize = 30;
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label("Bug 收集窗口");
        
            GUILayout.Space(10);
        
            bugName = EditorGUILayout.TextField("Bug Name:",bugName,GUILayout.Width(300));

            reportTime = EditorGUILayout.TextField("记录时间：",reportTime);
        
            desc = EditorGUILayout.TextField("具体描述：",desc,GUILayout.Height(150));

            progress = EditorGUILayout.Slider("当前进度：",progress,-1,1);

            selectObg = (GameObject)EditorGUILayout.ObjectField("赋值物体：",selectObg, typeof(GameObject), true);

            selectColor = EditorGUILayout.ColorField("赋值颜色：", selectColor);
        
            selectTag = EditorGUILayout.TagField("选择标签：",selectTag);

            GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            onlyToggle = EditorGUILayout.Toggle("这是单选框", onlyToggle);

            popup = EditorGUILayout.Popup("下拉选项", popup, PopupTitleSelectStringList);
        
            texture = (Texture)EditorGUILayout.ObjectField("选择图片：", texture, typeof(Texture), true);
        
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
        
            if (GUILayout.Button("关闭界面", GUILayout.Height(50)))
            {
                OnButtonClick();
            }
            GUILayout.EndHorizontal();
        }
    }

    void OnButtonClick()
    {
        Debug.LogError("Button click");
//        Close();
        Transform[] ts = Selection.transforms;
        Debug.Log(ts.Length);
    }
}
