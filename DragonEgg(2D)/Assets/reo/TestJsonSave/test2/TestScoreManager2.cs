using UnityEngine;
using UnityEngine.UI;

namespace App.SaveSystem
{
    /// <summary>
    /// �X�R�A�̉Z��\���A�ő�l�̍X�V��S���N���X
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public Text maxScoreText;
        public Text scoreText;

        private int maxScore;
        private int score;

        private void Start()
        {
            SavedDataStore.onLoadEvent.AddListener(() =>
            {
                maxScore = SavedDataStore.SaveData.MaxScore;
                UpdateScoreTexts();
            }); // ���[�h���ɕۑ����Ă����f�[�^��\��
            UpdateScoreTexts();
        }

        private void UpdateScoreTexts()
        {
            maxScoreText.text = maxScore.ToString();
            scoreText.text = score.ToString();
        }

        public void AddScore() // only button
        {
            score++;
            if (score > maxScore) // score��maxScore�𒴂��邲�Ƃ�maxScore���X�V
            {
                maxScore = score;
                SavedDataStore.SaveData.MaxScore = maxScore;
            }
            UpdateScoreTexts();
        }

        public void ClearScore() // only button
        {
            maxScore = 0;
            score = 0;
            UpdateScoreTexts();
        }
    }
}