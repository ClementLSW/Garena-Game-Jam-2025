using UnityEngine;
using System.Collections;

public class OneTimePulser : MonoBehaviour
{
    public float pulseDuration = 0.5f; // Total time for the pulse
    public float pulseScale = 1.2f;    // Max scale multiplier (e.g., 1.2 = 20% bigger)

    private Vector3 originalScale;
    private bool isPulsing = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void PulseOnce()
    {
        if (!isPulsing)
        {
            StartCoroutine(PulseRoutine());
        }
    }

    private IEnumerator PulseRoutine()
    {
        isPulsing = true;

        float halfDuration = pulseDuration / 2f;
        float timer = 0f;

        // Scale up
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float t = timer / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * pulseScale, t);
            yield return null;
        }

        // Scale down
        timer = 0f;
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float t = timer / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale * pulseScale, originalScale, t);
            yield return null;
        }

        transform.localScale = originalScale;
        isPulsing = false;
    }
}