using System.IO;
using UnityEngine;

namespace CodeBase.Infrastructure.SaveLoadSystem
{
    public static class DataHolder
    {
        private const string DATA_FOLDER = "/Data/";
        private const string FILE_FORMAT = ".json";

        public static void Save<T>(T data) where T : class
        {
            string directoryPath = Application.dataPath + DATA_FOLDER;
            string fileName = typeof(T).ToString() + FILE_FORMAT;
            string json = JsonUtility.ToJson(data, true);

            createDirectoryIfNeeded(directoryPath);

            File.WriteAllText(directoryPath + fileName, json);
        }

        public static bool Load<T>(out T data) where T : class
        {
            string directoryPath = Application.dataPath + DATA_FOLDER;
            string fileName = typeof(T).ToString() + FILE_FORMAT;
            
            bool hasData = false;
            data = default;

            if (File.Exists(directoryPath + fileName))
            {
                string json = File.ReadAllText(directoryPath + fileName);
                hasData = true;

                data = JsonUtility.FromJson<T>(json);
            }
            else
                Debug.Log("save file not found is path:     " + directoryPath + fileName);

            return hasData;
        }
        
        private static void createDirectoryIfNeeded(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}