using UnityEngine.Events;

namespace App.SaveSystem
{
    /// <summary>
    /// �Z�[�u�f�[�^��ǂݍ��񂾂���
    /// </summary>
    public static class SavedDataStore
    {
        public static UnityEvent onLoadEvent = new UnityEvent(); // ���[�h���ɌĂ΂��C�x���g
        public static SaveData SaveData
        {
            get => saveData;
            set => saveData = value;
        }
        private static SaveData saveData = new SaveData();
    }
}