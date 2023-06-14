using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public void BecomDynamic()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
