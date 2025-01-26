using UnityEngine;

public class BubbleFall : MonoBehaviour
{
    [Header("Rango de valores aleatorios")]
    [Tooltip("Rango para la velocidad vertical.")]
    public Vector2 verticalSpeedRange = new Vector2(0.5f, 1.5f);

    [Tooltip("Rango para la amplitud de oscilación horizontal.")]
    public Vector2 horizontalAmplitudeRange = new Vector2(0.2f, 0.8f);

    [Tooltip("Rango para la frecuencia de la oscilación horizontal.")]
    public Vector2 horizontalFrequencyRange = new Vector2(1f, 3f);

    [Header("Opcionales")]
    [Tooltip("Tiempo de vida de la burbuja antes de destruirse (en segundos).")]
    public float lifeTime = 10f;

    private float verticalSpeed;
    private float horizontalAmplitude;
    private float horizontalFrequency;
    private float initialX;
    void Start()
    {
        float randomeScaleGenerator = Random.Range(0.2f, 0.5f);

        transform.localScale = transform.localScale * randomeScaleGenerator;

        // Guardar la posición X inicial
        initialX = transform.position.x;

        // Randomizar los parámetros dentro de los rangos
        verticalSpeed = Random.Range(verticalSpeedRange.x, verticalSpeedRange.y);
        horizontalAmplitude = Random.Range(horizontalAmplitudeRange.x, horizontalAmplitudeRange.y);
        horizontalFrequency = Random.Range(horizontalFrequencyRange.x, horizontalFrequencyRange.y);

        // (Opcional) Destruir la burbuja después de lifeTime segundos
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Cálculo de oscilación horizontal con base en el tiempo
        float xOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;

        // Movimiento vertical descendente
        float yMovement = transform.position.y - (verticalSpeed * Time.deltaTime);

        // Actualizar posición
        transform.position = new Vector3(
            initialX + xOffset,
            yMovement,
            transform.position.z
        );
    }

}
