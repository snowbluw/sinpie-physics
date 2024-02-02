using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Dragable : MonoBehaviour
{
    private bool isTouched;
    public bool IsTouched { get {return isTouched; } }

    private Vector3 mousePositon = Vector3.zero;
    private float mZCoord;

    private void OnMouseDown()
    {
        isTouched = true;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mousePositon = gameObject.transform.position - GetMousePos();
        Debug.Log("touch");
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + mousePositon;
        Debug.Log("drag");
    }

    private void OnMouseUp()
    {
        isTouched = false;
    }
}
