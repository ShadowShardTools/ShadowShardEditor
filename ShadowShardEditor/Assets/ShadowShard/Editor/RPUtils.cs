﻿using System;
using UnityEngine;

namespace ShadowShard.Editor
{
    public static class RPUtils
    {
        public static string ConvertVector4ToGuid(Vector4 vector)
        {
            byte[] bytes = new byte[16];

            BitConverter.GetBytes(vector.x).CopyTo(bytes, 0);
            BitConverter.GetBytes(vector.y).CopyTo(bytes, 4);
            BitConverter.GetBytes(vector.z).CopyTo(bytes, 8);
            BitConverter.GetBytes(vector.w).CopyTo(bytes, 12);

            return new Guid(bytes).ToString("N"); // Specify "N" format for hyphen-less GUID string
        }
    
        public static Vector4 ConvertGuidToVector4(string guid)
        {
            byte[] guidBytes = Guid.ParseExact(guid, "N").ToByteArray(); // Parse the GUID without hyphens

            float x = BitConverter.ToSingle(guidBytes, 0);
            float y = BitConverter.ToSingle(guidBytes, 4);
            float z = BitConverter.ToSingle(guidBytes, 8);
            float w = BitConverter.ToSingle(guidBytes, 12);

            return new Vector4(x, y, z, w);
        }
        
        public static float AsFloat(uint val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static float AsFloat(int val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            return BitConverter.ToSingle(bytes, 0);
        }
        
        public static void SetGlobalKeyword(string keyword, bool state)
        {
            if (state)
                Shader.EnableKeyword(keyword);
            else
                Shader.DisableKeyword(keyword);
        }
    }
}