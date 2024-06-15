﻿using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class PopupEditor
    {
        private readonly GroupEditor _groupEditor;

        private const string BooleanDisplayedOptionsError = "The displayedOptions array should contain exactly two options.";

        public PopupEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));
            
            int enumOption = DrawPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.enumValueIndex;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.enumValueIndex = newValue;
            }
        }
        
        public bool DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return false;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.enumValueIndex > 0;
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.enumValueIndex = newValue;
            }
        }
        
        public bool DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return false;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.enumValueIndex > 0;
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                {
                    property.enumValueIndex = newValue;
                    RPUtils.SetGlobalKeyword(shaderGlobalKeyword, newValue > 0);
                }
            }
        }

        private bool IsDisplayedBooleanErrorMessage(string[] displayedOptions)
        {
            if (displayedOptions.Length == 2) 
                return true;
            
            EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
            return false;
        }
    }
}