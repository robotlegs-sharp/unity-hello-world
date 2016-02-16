using UnityEngine;
using robotlegs.bender.framework.api;
using robotlegs.bender.framework.impl;
using robotlegs.bender.bundles;
using helloworldmulticontext.config;
using robotlegs.bender.platforms.unity.extensions.contextview.impl;

namespace helloworldmulticontext
{
	public class ParentContext : MonoBehaviour
	{
		IContext parentContext;

		public void Start()
		{
			// A parent context, handles relationship of child / parent communication
			// It becomes parent when it's child contexts boot up and find that this context's view is parent of them
			parentContext = new Context ();
			parentContext.Install<UnityMultiContextBundle> () // Install MVCS Framework
				.Configure(new TransformContextView(transform));
		}
	}
}

