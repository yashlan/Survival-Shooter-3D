using UnityEngine;

public class Rectangle : IShape
{
    public void Draw() => Debug.Log("Inside Rectangle Draw() method");
}