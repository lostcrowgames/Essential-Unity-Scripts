using System.Collections;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float scaleTime = 1f; // The time it takes to scale the object
    public float scaleAmount = 0.9f; // The amount to scale the object by (90% in this case)

    private Vector3 originalScale; // The original scale of the object
    private float currentTime = 0f; // The current time

    void Start()
    {
        originalScale = transform.localScale; // Store the original scale of the object
    }

    public void ScaleDown()
    {
        Debug.Log("Scaling object down");
        currentTime = 0f; // Reset the current time

        // Start the ScaleDownCoroutine
        StartCoroutine(ScaleDownCoroutine());
    }

    IEnumerator ScaleDownCoroutine()
    {
        // Use a while loop to gradually scale the object over time
        while (currentTime <= scaleTime)
        {
            currentTime += Time.deltaTime; // Increment the current time

            float t = currentTime / scaleTime; // Calculate the interpolation value

            transform.localScale = Vector3.Lerp(originalScale, originalScale * scaleAmount, t); // Interpolate the scale of the object

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final scale is exact, in case of rounding errors
        transform.localScale = originalScale * scaleAmount;
    }

    public void ScaleUp()
    {
        Debug.Log("Scaling object up");
        currentTime = 0f; // Reset the current time

        // Start the ScaleUpCoroutine
        StartCoroutine(ScaleUpCoroutine());
    }

    IEnumerator ScaleUpCoroutine()
    {
        // Use a while loop to gradually scale the object over time
        while (currentTime <= scaleTime)
        {
            currentTime += Time.deltaTime; // Increment the current time

            float t = currentTime / scaleTime; // Calculate the interpolation value

            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, t); // Interpolate the scale of the object

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final scale is exact, in case of rounding errors
        transform.localScale = originalScale;
    }
}
