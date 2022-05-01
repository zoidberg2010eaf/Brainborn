using System;
using UnityEngine;
using UnityEngine.UI;

public static class GameHelper
{
    public static Vector2 ToCanvasPoint(this Vector2 point)
    {

        Vector2 zero = Vector2.zero;
        RectTransform component = UIPanelManager._Insance._PanelParent.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(component, point, Camera.main, out zero);
        return zero;

    }

    public static Vector2 CanvasToScreenPoint(RectTransform _point)
    {

        Vector2 zero = Vector2.zero;
        zero = RectTransformUtility.WorldToScreenPoint(Camera.main, _point.position);
        return zero;

    }
}