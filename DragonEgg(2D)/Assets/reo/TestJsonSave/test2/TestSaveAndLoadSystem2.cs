using System;
using System.IO;
using UnityEngine;

namespace App.SaveSystem
{
    public static class SaveAndLoadSystem<T> where T : class, new()
    {
        private const string FolderName = "SaveData";

        public static void Save(T data)
        {
            var jsonData = JsonUtility.ToJson(data); // json�`���ɕϊ�

            using (var sw = new StreamWriter(GetPath(data), false)) // �㏑��(�f�[�^���Ȃ��Ȃ�V�K�쐬)
            {
                try
                {
                    sw.Write(jsonData); // �Z�[�u
                    Debug.Log($"Saved {data.GetType().Name} : \n{jsonData}"); // debugonly
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        public static T Load()
        {
            var data = new T();
            try
            {
                using (var fs = new FileStream(GetPath(data), FileMode.OpenOrCreate))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        var jsonData = sr.ReadToEnd();
                        Debug.Log($"Loaded {data.GetType().Name} : \n{jsonData}"); // debugonly
                        data = JsonUtility.FromJson<T>(jsonData);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }
            return data;
        }
        public static void Delete()
        {
            File.Delete(GetPath(new T())); // �w�肵���p�X�̃t�@�C�����폜
            Debug.Log($"Delete SaveData");
        }

    private static string GetPath(T data)
        {
            var directoryPath = Application.persistentDataPath + "\\" + FolderName;
            Directory.CreateDirectory(directoryPath); // �w�肵���p�X�Ƀt�H���_���Ȃ��Ȃ�, �t�H���_��V�K�쐬
            return directoryPath + $"\\{data.GetType().Name}" + ".json";
        }
    }
}