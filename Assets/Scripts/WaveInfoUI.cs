using System;
using TMPro;
using UnityEngine;

public class WaveInfoUI : MonoBehaviour
{
    [SerializeField] WaveDirector waveDirector;

    [SerializeField] GameObject enemyInfoPanel;
    [SerializeField] GameObject restInfoPanel;
    
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI enemyText;
    [SerializeField] TextMeshProUGUI restTimeText;

    void Start() {
        waveDirector.OnWaveBegin += WaveDirector_OnWaveBegin;
        waveDirector.OnWaveClear += WaveDirector_OnWaveClear;
        waveDirector.OnRemainingEnemiesChanged += UpdateEnemyInfo;
        waveDirector.OnRestTimeChanged += UpdateRestTimeInfo;
    }

    void WaveDirector_OnWaveClear() {
        TogglePanel(false);
    }

    void WaveDirector_OnWaveBegin(int current, int total) {
        TogglePanel(true);
        UpdateWaveInfo(current, total);
    }

    void UpdateRestTimeInfo(float timer) {
        int totalSeconds = Mathf.RoundToInt(Mathf.Max(0, timer));

        restTimeText.text = $"{totalSeconds / 60}:{totalSeconds % 60:00}";
    }

    void UpdateEnemyInfo(int remaining) {
        enemyText.text = remaining.ToString();
    }

    void UpdateWaveInfo(int current, int total) {
        waveText.text = $"{current + 1}/{total}";
    }

    void TogglePanel(bool waveRunning) {
        enemyInfoPanel.SetActive(waveRunning);
        restInfoPanel.SetActive(!waveRunning);
    }
}