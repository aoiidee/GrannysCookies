using UnityEngine;

public class TestPointerTranslation : MonoBehaviour
{
    [SerializeField] private Camera c;
    public void AdjustedClick(Vector2 pos)
    {
        print(pos);
        Vector2 testPos = c.ScreenToWorldPoint(pos * new Vector2(c.pixelWidth, c.pixelHeight));
        //print(testPos);
        GameObject test = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        test.transform.position = new Vector3(testPos.x, testPos.y, 0f);
    }
}
