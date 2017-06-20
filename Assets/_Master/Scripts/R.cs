using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class R
{
    /// <summary>
    /// Finds the view that your look for by it's name witch is the id
    /// </summary>
    /// <param name="context">The script that is calling the function</param>
    /// <param name="id">The view id that your trying to find</param>
    /// <returns>new View with the object in it<returns>
    internal static View findViewById(string id)
    {
        foreach (View view in UnityEngine.Object.FindObjectsOfType<View>())
        {
            if (view.id.Equals(id))
            {
#if UNITY_EDITOR
                UnityEditor.Selection.activeObject = view;
#endif
                return view;
            }
        }
        return null;
    }
}