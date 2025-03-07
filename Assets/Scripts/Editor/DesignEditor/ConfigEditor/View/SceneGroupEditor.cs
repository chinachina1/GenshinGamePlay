﻿using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Unity.Code.NinoGen;
namespace TaoTie
{
    public class SceneGroupEditor: BaseEditorWindow<ConfigSceneGroup>
    {
        protected override string folderPath => base.folderPath + "/EditConfig/SceneGroup";
        protected override byte[] Serialize(ConfigSceneGroup data)
        {
            return Serializer.Serialize(data);
        }
        public void Update()
        {
            OdinDropdownHelper.sceneGroup = data;
        }
        [MenuItem("Tools/配置编辑器/SceneGroup")]
        static void OpenSceneGroup()
        {
            EditorWindow.GetWindow<SceneGroupEditor>().Show();
        }
        [OnOpenAsset(0)]
        public static bool OnBaseDataOpened(int instanceID, int line)
        {
            var data = EditorUtility.InstanceIDToObject(instanceID) as TextAsset;
            var path = AssetDatabase.GetAssetPath(data);
            return InitializeData(data,path);
        }

        public static bool InitializeData(TextAsset asset,string path)
        {
            if (asset == null) return false;
            if (path.EndsWith(".json") && JsonHelper.TryFromJson<ConfigSceneGroup>(asset.text,out var json))
            {
                var win = EditorWindow.GetWindow<SceneGroupEditor>();
                OdinDropdownHelper.sceneGroup = json;
                win.Init(json,path,true);
                return true;
            }
            return false;
        }
    }
}