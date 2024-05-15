using UnityEngine;

public class RotateGlare : MonoBehaviour
{
    // Döndürme hýzýný tanýmlayýn. Burada her eksen için ayrý hýz belirleyebilirsiniz.
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Örneðin, sadece Y ekseni etrafýnda döndürülecek.

    // Update metodu her frame'de bir kez çaðrýlýr
    void Update()
    {
        // Time.deltaTime ile frame baðýmsýz olarak döndürme saðlanýr.
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
