using UnityEngine;
using UnityEngine.UI;
using helloworld.events;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;

namespace helloworld.views
{
	[RequireComponent(typeof(Image))]
	public class ClickCountView : EventView
	{
		private const string DEFAULT_VALUE = "Not Clicked";
		private Text textComponent;

		protected override void Start ()
		{
			base.Start ();
			CreateLabel(DEFAULT_VALUE);
		}

		public void ChangeButtonText(int numberOfTimesClicked)
		{
			textComponent.text = numberOfTimesClicked == 0 ? DEFAULT_VALUE : "Clicked " + numberOfTimesClicked + " times";
		}

		private void CreateLabel(string labelText)
		{
			gameObject.GetComponent<Image> ();
			RectTransform rectTransform = gameObject.GetComponent<RectTransform> ();
			rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 150);
			rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 40);
			GameObject child = new GameObject ("text");
			child.transform.SetParent (transform);
			textComponent = child.AddComponent<Text> ();
			textComponent.text = labelText;
			textComponent.font = Font.CreateDynamicFontFromOSFont ("Arial", 200);
			textComponent.color = Color.black;
			textComponent.alignment = TextAnchor.MiddleCenter;
			child.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}
	}
}