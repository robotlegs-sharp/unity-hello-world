using System;
using robotlegs.bender.framework.api;
using UnityEngine;
using helloworld.views;

namespace helloworldmulticontext.config
{
	public class AddHelloWorldButtons : IConfig
	{
		[Inject] public IContext context;
		[Inject] public Transform contextViewTransform;

		public void Configure ()
		{
			context.AfterInitializing(AddViews);
		}

		public void AddViews ()
		{
			GameObject buttonView = new GameObject ("Button view");
			buttonView.transform.parent = contextViewTransform;
			buttonView.AddComponent<ButtonView> ();
			RectTransform rectTransform = buttonView.AddComponent<RectTransform>();
			rectTransform.anchorMax = rectTransform.anchorMin = new Vector2(0, 1);

			GameObject clickCountView = new GameObject ("Click Count view");
			clickCountView.transform.parent = contextViewTransform;
			clickCountView.AddComponent<ClickCountView> ();
			rectTransform = clickCountView.GetComponent<RectTransform>();
			rectTransform.anchorMax = rectTransform.anchorMin = new Vector2(0, 1);
		}
	}
}

