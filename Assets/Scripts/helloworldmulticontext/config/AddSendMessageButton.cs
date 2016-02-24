using System;
using Robotlegs.Bender.Framework.API;
using UnityEngine;
using helloworldmulticontext.view;

namespace helloworldmulticontext.config
{
	public class AddSendMessageButton : IConfig
	{
		[Inject] public IContext context;
		[Inject] public Transform contextViewTransform;

		public void Configure ()
		{
			context.AfterInitializing(AddViews);
		}

		private void AddViews()
		{
			GameObject buttonView = new GameObject ("Send Message View");
			buttonView.transform.parent = contextViewTransform;
			buttonView.AddComponent<SendMessageView> ();
		}
	}
}

