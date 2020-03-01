using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Collider2D)))]
[RequireComponent((typeof(Rigidbody2D)))]
public class Newton : MonoBehaviour
{
    private Vector3 offset;
    private Rigidbody2D rb;
    private SpringJoint2D spr;
      
    void Start()
    {rb = GetComponent<Rigidbody2D>(); }

    private void OnMouseDown()
    {
        spr.enableCollision = true;
        spr.dampingRatio = 1;
        spr.autoConfigureDistance = false;
        spr.distance = 1;
        
        Vector3 currScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(currScreenPoint);
        spr.gameObject.AddComponent<SpringJoint2D>();
        Vector2 transformedSp = gameObject.transform.InverseTransformPoint(worldPoint);
        spr.anchor = transformedSp;
    }

    private void OnMouseDrag()
    {
        Vector3 currScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,0);
        Vector3 currposition = Camera.main.ScreenToWorldPoint(currScreenPoint) + offset;
        if (spr != null)
        {
            spr.connectedAnchor = currposition;
        }
    }

    private void OnMouseUp()
    {
        Destroy(spr);
    }
}
