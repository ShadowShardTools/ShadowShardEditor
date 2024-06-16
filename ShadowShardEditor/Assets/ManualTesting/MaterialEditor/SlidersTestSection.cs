﻿using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class SlidersTestSection : MaterialSection
    {
        protected Property Color = new("_Color");
        protected Property BaseMap = new("_BaseMap");
        protected Property FloatValue = new("_FloatValue");
        protected Property FloatMinValue = new("_FloatMinValue");
        protected Property FloatMaxValue = new("_FloatMaxValue");
        protected Property IntValue = new("_IntValue");
        protected Property VectorValue = new("_VectorValue");
        protected Property ToggleValue = new("_ToggleValue");
        protected Property EnumValue = new("_EnumValue");
        protected Property ShaderKeywordToggle = new("_ShaderKeywordToggle");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        private readonly FloatRange _testFloatRange = new(0.0f, 10.0f);

        public SlidersTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            FloatValue.Find(properties);
            FloatMinValue.Find(properties);
            FloatMaxValue.Find(properties);
            IntValue.Find(properties);
            VectorValue.Find(properties);
            ToggleValue.Find(properties);
            EnumValue.Find(properties);
            ShaderKeywordToggle.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawSlider(_floatLabel, FloatValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawSlider(_floatLabel, FloatValue.MaterialProperty, 1);
            editor.DrawFromVector3ParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.X, _testFloatRange, 1);
            editor.DrawFromVector3ParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Y, 1);
            editor.DrawVector3Sliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawVector3Sliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawMinMaxSlider(_floatLabel, FloatMinValue.MaterialProperty, FloatMaxValue.MaterialProperty, _testFloatRange,1);
            editor.DrawMinMaxSlider(_floatLabel, FloatMinValue.MaterialProperty, FloatMaxValue.MaterialProperty,1);
            editor.DrawMinMaxVector4StartSlider(_vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawMinMaxVector4StartSlider(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawMinMaxVector4EndSlider(_vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawMinMaxVector4EndSlider(_vectorLabel, VectorValue.MaterialProperty, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}