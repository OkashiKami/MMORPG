using UnityEngine;

[RequireComponent(typeof(View))]
public class SetColorPickerColor : MonoBehaviour
{
	[System.NonSerialized] View mWidget;

	public void SetToCurrent ()
	{
		if (mWidget == null) mWidget = GetComponent<View>();
		if (UIColorPicker.current != null)
			mWidget.color = UIColorPicker.current.value;
	}
}
