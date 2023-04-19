using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistanceScript : MonoBehaviour
{
    [SerializeField] private float cd;
    [SerializeField] private Mesh mesh;
    private new Rigidbody rigidbody;
    Vector3[] mVertices;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mVertices = mesh.vertices;
    }

    private void FixedUpdate()
    {
        var p = 1.225f;
        var a = Area();
        var v = rigidbody.velocity.magnitude;

        var direction = -rigidbody.velocity.normalized;
        var forceAmount = (p * v * v * cd * a) / 2;
        rigidbody.AddForce(forceAmount * direction);
    }

    private float Area()
    {
        float result = 0;
        for (int p = mVertices.Length - 1, q = 0; q < mVertices.Length; p = q++)
        {
            result += (Vector3.Cross(mVertices[q], mVertices[p])).magnitude;
        }
        return result * 0.5f;
    }
}
