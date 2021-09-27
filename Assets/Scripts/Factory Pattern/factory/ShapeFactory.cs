using System;
using UnityEngine;

public class ShapeFactory : MonoBehaviour
{
    public IShape getShape(string shapeType)
    {
        if (shapeType == null) return null;

        if (shapeType.equalsIgnoreCase("CIRCLE"))     
            return new Circle();
        else if (shapeType.equalsIgnoreCase("RECTANGLE")) 
            return new Rectangle();
        else if (shapeType.equalsIgnoreCase("SQUARE"))    
            return new Square();

        return null;
    }
}

//utilitas untuk membuat method EqualsIgnoreCase
internal static class StringExtensionsUtil
{
    public static bool equalsIgnoreCase(this string str1, string str2)
    {
        return string.Equals(str1, str2, StringComparison.InvariantCultureIgnoreCase);
    }
}
