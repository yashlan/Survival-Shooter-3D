using UnityEngine;

public class FactoryPatternDemo : MonoBehaviour
{

    void Start()
    {
        //menambahkan component ShapeFactory pada gameObject
        ShapeFactory shapeFactory = gameObject.AddComponent<ShapeFactory>();

        //get an object of Circle and call its draw method.
        IShape shape1 = shapeFactory.getShape("CIRCLE");

        //call draw method of Circle
        shape1.Draw();

        //get an object of Rectangle and call its draw method.
        IShape shape2 = shapeFactory.getShape("RECTANGLE");

        //call draw method of Rectangle
        shape2.Draw();

        //get an object of Square and call its draw method.
        IShape shape3 = shapeFactory.getShape("SQUARE");

        //call draw method of square
        shape3.Draw();
    }
}
