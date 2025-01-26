using System.Collections;
using UnityEngine;

public class MainMenuMoveImage : MonoBehaviour
{

    public Vector3 targetPosition;

    [Header("Duraci�n del movimiento")]
    public float duration = 2f;   // 2 segundos de transici�n
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

            // Aplicamos la funci�n de 'ease in-out'
            float easeValue = EaseInOut(t);

            // Interpolamos la posici�n seg�n la funci�n
            transform.position = Vector3.Lerp(transform.position, targetPosition, easeValue);

            yield return null;  // Espera al siguiente frame
        }

        // Al finalizar, forzamos la posici�n final para evitar 
        // cualquier imprecisi�n por d�cimas de segundo
        transform.position = targetPosition;
    }

    // Funci�n de Ease In-Out (t^2 * (3 - 2t))
    private float EaseInOut(float t)
    {
        return t * t * (3f - 2f * t);
    }
}
