using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine.UI;
using helloworld.events;
using UnityEngine;

namespace helloworld.views
{
	public class ButtonView : EventView
	{
		Text textComponent;

		protected override void Start ()
		{
			base.Start ();
			CreateButton("Add One Click To Model").onClick.AddListener (HandleButtonClicked);
		}

		public void ChangeButtonText(int numberOfTimesClicked)
		{
			textComponent.text = numberOfTimesClicked == 0 ? "Click me" : "Clicked " + numberOfTimesClicked + " times";
		}

		public void HandleButtonClicked()
		{
			dispatcher.Dispatch(new ClickCountEvent(ClickCountEvent.Type.INCREMENT));
		}

		private Button CreateButton(string labelText)
		{			
			Button button = gameObject.AddComponent<Button> ();
			button.targetGraphic = gameObject.AddComponent<Image> ();
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
			return button;
		}
	}
}