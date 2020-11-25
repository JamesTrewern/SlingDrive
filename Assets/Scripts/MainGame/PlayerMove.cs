using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform SlingPointTransform;
    public float Acceleration = 0.01f;
    public Vector2 DistanceVector;
    private Transform PlayerTransform;
    private Rigidbody2D PlayerRB;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float X1, X2, Y1, Y2;
        
        X1 = PlayerTransform.position.x;
        Y1 = PlayerTransform.position.y;
        X2 = SlingPointTransform.position.x;
        Y2 = SlingPointTransform.position.y;
        DistanceVector = FindDistanceVector(X1, Y1, X2, Y2);
        if (Input.GetMouseButton(0))
        {
            PlayerRB.AddForce(CalculateForce(DistanceVector));
        }
    }

    Vector2 CalculateForce(Vector2 Distance)
    {
        Vector2 Force = new Vector2(0,0);
        Force = Distance * new Vector2(Acceleration, Acceleration);
        return Force;
    }

    Vector2 FindDistanceVector(float X1, float Y1, float X2, float Y2)
    {
        float XDis, YDis;
        XDis = X2 - X1;
        YDis = Y2 - Y1;
        return new Vector2(XDis, YDis);
    }
}
