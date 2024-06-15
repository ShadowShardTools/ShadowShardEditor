﻿using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class GroupEditor
    {
        public void DrawVertical(GUIStyle styles, Action drawCall)
        {
            EditorGUILayout.BeginVertical(styles);
            drawCall.Invoke();
            EditorGUILayout.EndVertical();
        }
        
        public void DrawIndented(int indentLevel, Action drawCall)
        {
            EditorGUI.indentLevel += indentLevel;
            drawCall.Invoke();
            EditorGUI.indentLevel -= indentLevel;
        }
        
        public void DrawDisabled(bool isDisabled, Action drawCall)
        {
            EditorGUI.BeginDisabledGroup(isDisabled);
            drawCall.Invoke();
            EditorGUI.EndDisabledGroup();
        }

        public void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall)
        {
            DrawDisabled(isDisabled, Draw);
            return;

            void Draw() => 
                DrawIndented(indentLevel, drawCall);
        }
        
        public void DrawGroup(bool isDisabled, Action drawCall)
        {
            DrawVertical(EditorStyles.helpBox, Draw);
            return;

            void Draw() => 
                DrawDisabled(isDisabled, drawCall);
        }
        
        public void DrawGroup(GUIContent label, bool isDisabled, Action drawCall)
        {
            DrawVertical(EditorStyles.helpBox, Draw);
            return;

            void Draw()
            {
                EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
                DrawDisabled(isDisabled, drawCall);
            }
        }
    }
}