using System.Collections;
using UnityEngine;

public class MainMenuMoveImage : MonoBehaviour
{

    public Vector3 targetPosition;

    [Header("Duración del movimiento")]
    public float duration = 2f;   // 2 segundos de transición
    public void RepositionImage()
    {
        StartCoroutine(RepositionCoroutine()); 
    }

    IEnumerator RepositionCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Normalizamos el tiempo para que vaya de 0 a 1
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Aplicamos la función de 'ease in-out'
            float easeValue = EaseInOut(t);

            // Interpolamos la posición según la función
            transform.position = Vector3.Lerp(transform.position, targetPosition, easeValue);

            yield return null;  // Espera al siguiente frame
        }

        // Al finalizar, forzamos la posición final para evitar 
        // cualquier imprecisión por décimas de segundo
        transform.position = targetPosition;
    }

    // Función de Ease In-Out (t^2 * (3 - 2t))
    private float EaseInOut(float t)
    {
        return t * t * (3f - 2f * t);
    }
}
