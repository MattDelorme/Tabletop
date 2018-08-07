using UnityEditor;
using UnityEngine;
using Shared.Unity;

namespace Tabletop.Unity.Editor
{
    [CustomPropertyDrawer(typeof(TabletopStats))]
    public class TabletopStatsDrawer : PropertyDrawer
    {
        private readonly string[] propertyNames = new string[]
        {
            "Movement",
            "WS",
            "BS",
            "S",
            "T",
            "W",
            "I",
            "A",
            "Ld"
        };

        private bool foldout;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Vector2 size = new Vector2(24f, EditorGUIUtility.singleLineHeight);

            foldout = EditorGUI.Foldout(new Rect(position.position, new Vector2(position.size.x, EditorGUIUtility.singleLineHeight)), foldout, label);

            var indentedRect = EditorGUI.IndentedRect(position);

            if (foldout)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    var labelPosition = new Vector2(indentedRect.x + i * 28, indentedRect.y + EditorGUIUtility.singleLineHeight);
                    var labelRect = new Rect(labelPosition, size);
                    GUI.Label(labelRect, propertyNames[i]);
                    
                    var serializedProperty = property.FindPropertyRelative(propertyNames[i]);

                    var fieldPosition = new Vector2(indentedRect.x + i * 28, indentedRect.y + EditorGUIUtility.singleLineHeight * 2);
                    var fieldRect = new Rect(fieldPosition, size);
                    serializedProperty.intValue = GUIExtensions.IntField(fieldRect, serializedProperty.intValue);
                }
            }

            EditorGUI.indentLevel--;
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!foldout)
            {
                return base.GetPropertyHeight(property, label);
            }
            else
            {
                return EditorGUIUtility.singleLineHeight * 3;
            }
        }
    }
}
