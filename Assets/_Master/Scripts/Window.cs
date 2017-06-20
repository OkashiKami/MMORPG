using UnityEngine;
using System.Collections;
public class Window : MonoBehaviour
{
    public void ShowView(View view)
    {
        if (view == null) return;
        while (view.alpha < 1) view.alpha += 0.1f;
    }
    public void HideView(View view)
    {
        if (view == null) return;
        while (view.alpha > 0) view.alpha -= 0.1f;
    }
}