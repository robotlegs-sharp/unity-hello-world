using System;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine.UI;
using UnityEngine;
using helloworld.events;

namespace helloworldmulticontext.view
{
	public class SendMessageView : EventView, ISendMessageView
	{
		Text textComponent;

		private Text text;

		private GameObject buttonGO;

		protected override void Start ()
		{
			base.Start ();
			VerticalLayoutGroup verticalLayout = gameObject.AddComponent<VerticalLayoutGroup>();
			verticalLayout.spacing = 10;

			CreateInputField();
			MakeButton();
		}

		private void MakeButton()
		{
			buttonGO = new GameObject();
			buttonGO.transform.parent = transform;
			buttonGO.AddComponent<Image>();
			GameObject textGO = new GameObject("Text");
			Text text = textGO.AddComponent<Text>();
			text.text = "Send Message";
			text.color = Color.black;
			text.font = Font.CreateDynamicFontFromOSFont ("Arial", 200);
			text.alignment = TextAnchor.MiddleCenter;
			textGO.transform.SetParent(buttonGO.transform, false);
			Button button = buttonGO.AddComponent<Button>();
			button.onClick.AddListener(OnClick);
		}

		private void OnClick()
		{
			dispatcher.Dispatch(new MessageEvent(MessageEvent.Type.SEND, text.text));
		}

		private void CreateInputField()
		{
			GameObject inputFieldGO = new GameObject("Input Field");
			InputField inputField = inputFieldGO.AddComponent<InputField>();
			inputFieldGO.AddComponent<Image>();

			GameObject textGO = new GameObject("Text");
			text = CreateText(textGO, "Message Text");

			inputField.textComponent = text;
			inputField.text = "Message Text";

			inputFieldGO.transform.SetParent(transform, false);
			textGO.transform.SetParent(inputFieldGO.transform, false);
		}

		private Text CreateText(GameObject gameObject, string startingText)
		{
			Text text = gameObject.AddComponent<Text>();
			text.text = startingText;
			text.font = Font.CreateDynamicFontFromOSFont ("Arial", 200);
			text.color = Color.red;
			text.alignment = TextAnchor.MiddleCenter;
			RectTransform rt = text.GetComponent<RectTransform>();
			rt.anchorMin = Vector2.zero;
			rt.anchorMax = Vector2.one;
			return text;
		}
	}
}

