using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform MyrectTransform;
    Rect safearea;
    Vector2 MinAnchor;
    Vector2 MaxAnchor;
    private void Awake()
    {
        MyrectTransform = GetComponent<RectTransform>();
        safearea = Screen.safeArea;
        FixUI();
    }
    void FixUI()
    {
        safearea = Screen.safeArea;
        // minachor gonna take (0;0) and max gonna take size of screnn 
        MinAnchor = safearea.position;
        MaxAnchor = MinAnchor + safearea.size;
        // transformed to values bettwen 0 and 1
        MinAnchor.x /= Screen.width;
        MinAnchor.y /= Screen.height;
        MaxAnchor.x /= Screen.width;
        MaxAnchor.y /= Screen.height;
        //impliment values
        MyrectTransform.anchorMin = MinAnchor;
        MyrectTransform.anchorMax = MaxAnchor;
    }
}
