using UnityEngine;
using System.Linq;
[ExecuteInEditMode]
public class ShapeBehavior : MonoBehaviour
{
    public float shapeSize;
    private Vector3 sizeOfShape;
    internal GameObject shapes;
    public void Start()
    {
        shapes = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        sizeOfShape = new Vector3(shapeSize, shapeSize, shapeSize);
        transform.localScale = sizeOfShape;
    }
}
