using System;
using UnityEngine.UI;
using UnityEngine;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;

namespace helloworldmulticontext.view
{
	public class ReceiveMessageView : EventView, IReceiveMessageView
	{
		Text textComponent;

		protected override void Start ()
		{
			base.Start ();
			CreateText("Receive Message View");
		}

		public void ReceivedMessage(string message)
		{
			textComponent.text = message;
		}

		private void CreateText(string labelText)
		{
			gameObject.AddComponent<Image> ();
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

		public void ReciveMessage (string message)
		{
			textComponent.text = "Received: " + message;
		}
	}
}

