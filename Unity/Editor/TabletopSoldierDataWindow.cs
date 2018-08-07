using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tabletop.Unity.Editor
{
    public class TabletopSoldierDataWindow : EditorWindow
    {
        private TabletopSoldierDataContainer tabletopSoldierDataContainer;
        private UnityEditor.Editor editor;

        private string[] files;
        private string[] teamNames;
        private int selectedTeamIndex;

        private const string DATA_DIRECTORY = "SoldierData";

        [MenuItem("Window/Tabletop/Soldier Data Window")]
        public static void OpenWindow()
        {
            var tabletopSoldierDataWindow = EditorWindow.GetWindow<TabletopSoldierDataWindow>();
            tabletopSoldierDataWindow.titleContent = new GUIContent("Soldier Data Window");
        }

        void OnEnable()
        {
            if (tabletopSoldierDataContainer != null)
            {
                editor = UnityEditor.Editor.CreateEditor(tabletopSoldierDataContainer);
            }

            refreshFiles();
        }

        void refreshFiles()
        {
            string dataPath = Path.Combine(Application.persistentDataPath, DATA_DIRECTORY);
            files = Directory.GetFiles(dataPath);
            teamNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                teamNames[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Create", GUILayout.MaxWidth(EditorGUIUtility.labelWidth)))
            {
                tabletopSoldierDataContainer = ScriptableObject.CreateInstance<TabletopSoldierDataContainer>();
                editor = UnityEditor.Editor.CreateEditor(tabletopSoldierDataContainer);

                tabletopSoldierDataContainer.TabletopSoldierTeamData = new TabletopSoldierTeamData();
            }

            EditorGUI.BeginChangeCheck();
            selectedTeamIndex = EditorGUILayout.Popup(selectedTeamIndex, teamNames, GUILayout.MaxWidth(EditorGUIUtility.labelWidth));
            if (EditorGUI.EndChangeCheck())
            {
                var jsonData = File.ReadAllText(files[selectedTeamIndex]);

                if (tabletopSoldierDataContainer == null)
                {
                    tabletopSoldierDataContainer = ScriptableObject.CreateInstance<TabletopSoldierDataContainer>();
                    editor = UnityEditor.Editor.CreateEditor(tabletopSoldierDataContainer);
                }

                tabletopSoldierDataContainer.TabletopSoldierTeamData = JsonUtility.FromJson<TabletopSoldierTeamData>(jsonData);
            }

            if (GUILayout.Button("Refresh", GUILayout.MaxWidth(EditorGUIUtility.labelWidth)))
            {
                refreshFiles();
            }

            if (GUILayout.Button("Save", GUILayout.MaxWidth(EditorGUIUtility.labelWidth)))
            {
                save();
            }

            if (editor != null)
            {
                EditorGUI.BeginChangeCheck();
                editor.DrawDefaultInspector();
                if (EditorGUI.EndChangeCheck())
                {
//                    save();
                }
            }
        }

        private void save()
        {
            if (!string.IsNullOrEmpty(tabletopSoldierDataContainer.TabletopSoldierTeamData.Name))
            {
                string dataPath = Path.Combine(Application.persistentDataPath, DATA_DIRECTORY);
                Directory.CreateDirectory(dataPath);
                string filePath = Path.Combine(dataPath, tabletopSoldierDataContainer.TabletopSoldierTeamData.Name + ".json");
                if (!string.IsNullOrEmpty(filePath))
                {
                    string jsonData = JsonUtility.ToJson(tabletopSoldierDataContainer.TabletopSoldierTeamData, true);
                    File.WriteAllText(filePath, jsonData);
                }
            }
        }
    }
}
