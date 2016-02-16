using System;
using robotlegs.bender.framework.api;
using UnityEngine;
using helloworldmulticontext.view;

namespace helloworldmulticontext.config
{
	public class AddReceiveMessageButton : IConfig
	{
		[Inject] public IContext context;
		[Inject] public Transform contextViewTransform;

		public void Configure ()
		{
			context.AfterInitializing(AddViews);
		}

		private void AddViews()
		{
			GameObject buttonView = new GameObject ("Receive Message View");
			buttonView.transform.parent = contextViewTransform;
			buttonView.AddComponent<ReceiveMessageView> ();
		}
	}
}

