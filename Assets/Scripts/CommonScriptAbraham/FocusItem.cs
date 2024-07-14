using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;


public class FocusItem : BaseTouchable
{
	[SerializeField] private bool canFocus = true;
	[SerializeField] private UnityEvent<bool> canFocusChangedState;
	[SerializeField] private bool let_toggle_focus = true;
	[SerializeField] private PriorityFocus priority;

	public bool CanFocus { get { return canFocus; } set { canFocus = value; } }
	public PriorityFocus Priority { get { return priority; } set { priority = value; } }

	public void ToggleFocus()
	{
		if (!let_toggle_focus) return;


		CanFocus = !CanFocus;
		canFocusChangedState?.Invoke(!CanFocus);
	}

	public override void Action()
	{
		ToggleFocus();
	}


}

public enum PriorityFocus
{
	Low,
	Middle,
	High
}