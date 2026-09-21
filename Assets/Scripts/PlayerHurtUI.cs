using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurtUI : MonoBehaviour
{
    [SerializeField] Image hurtImage;
    [SerializeField] PlayerHealth playerHealth;

    [Header("Vignette Settings")] 
    [SerializeField] float maxAlpha = 0.5f;
    [SerializeField] float fadeDuration = 0.3f;

    Coroutine flashCoroutine;

    void Awake() {
        SetAlpha(0f);
    }

    void Start() {
        playerHealth.OnHealthChange += PlayHurtVignette;
    }

    void PlayHurtVignette(float cur, float max) {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FadeHurtVignette());
    }

    IEnumerator FadeHurtVignette() {
        SetAlpha(maxAlpha);

        float time = 0f;

        while (time < fadeDuration) {
            time += Time.deltaTime;

            float t = time / fadeDuration;
            float alpha = Mathf.Lerp(maxAlpha, 0f, t);
            
            SetAlpha(alpha);

            yield return null;
        }

        SetAlpha(0f);
        flashCoroutine = null;
    }

    void SetAlpha(float alpha) {
        var color = hurtImage.color;
        color.a = alpha;
        hurtImage.color = color;
    }
}