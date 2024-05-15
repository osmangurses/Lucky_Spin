using UnityEngine;

public class RotateGlare : MonoBehaviour
{
    // D�nd�rme h�z�n� tan�mlay�n. Burada her eksen i�in ayr� h�z belirleyebilirsiniz.
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // �rne�in, sadece Y ekseni etraf�nda d�nd�r�lecek.

    // Update metodu her frame'de bir kez �a�r�l�r
    void Update()
    {
        // Time.deltaTime ile frame ba��ms�z olarak d�nd�rme sa�lan�r.
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
