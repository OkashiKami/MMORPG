//-------------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2017 Tasharen Entertainment Inc
//-------------------------------------------------

using UnityEngine;

/// <summary>
/// Makes it possible to animate a color of the widget.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(View))]
public class AnimatedColor : MonoBehaviour
{
	public Color color = Color.white;
	
	View mWidget;

	void OnEnable () { mWidget = GetComponent<View>(); LateUpdate(); }
	void LateUpdate () { mWidget.color = color; }
}
