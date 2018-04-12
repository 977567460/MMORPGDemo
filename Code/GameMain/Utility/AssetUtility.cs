﻿using UnityEngine;

namespace GameMain
{
    public static class AssetUtility
    {

        public static string GetDataTableAsset(string assetName)
        {
            return string.Format("Assets/GameMain/DataTables/{0}.txt", assetName);
        }

        public static string GetDictionaryAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.xml", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetFontAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Localization/{0}/Fonts/{1}.ttf", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return string.Format("Assets/GameMain/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetFairyGuiPackageAsset(string packageName)
        {
            return string.Format("Assets/GameMain/UI/UIPackage/{0}", packageName);
        }

        public static string GetLuaAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Lua/{0}", assetName);
        }

        public static string GetSkillScriptAsset(string assetName)
        {
            return string.Format("Assets/GameMain/Configs/ActorSkill/{0}", assetName);
        }
    }
}
