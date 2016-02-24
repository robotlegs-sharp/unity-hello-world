using UnityEngine;
using helloworld.controller.commands;
using helloworld.events;
using helloworld.models;
using helloworld.views;
using helloworld.views.mediators;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Framework.API;

namespace helloworld.config
{
	public class HelloWorldConfig : IConfig
	{
		[Inject] public IEventCommandMap eventCommandMap;
		[Inject] public IMediatorMap mediatorMap;
		[Inject] public IInjector injector;
		[Inject] public IContext context;
		[Inject] public Transform contextViewTransform;


		public void Configure ()
		{
			eventCommandMap.Map (ClickCountEvent.Type.INCREMENT).ToCommand<IncrementClickCounterCommand>();
			mediatorMap.Map<ButtonView> ().ToMediator<ButtonMediator> ();
			mediatorMap.Map<ClickCountView> ().ToMediator<ClickCountMediator> ();
			injector.Map<IClickCountModel> ().ToSingleton<ClickCountModel> ();

			context.AfterInitializing (StartApplication);
		}

		private void StartApplication()
		{
			GameObject buttonView = new GameObject ("Button view");
			buttonView.transform.parent = contextViewTransform;
			buttonView.AddComponent<ButtonView> ();
			RectTransform rectTransform = buttonView.AddComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(0.5f, 0.5f);

			CreateClickCountView(Vector2.zero, new Vector2(0, 1));
			CreateClickCountView(new Vector2(Screen.width, 0), new Vector2(1, 1));
		}

		private void CreateClickCountView(Vector2 anchorPosition, Vector2 pivot)
		{
			GameObject clickCountView = new GameObject ("Click Count view");
			clickCountView.transform.parent = contextViewTransform;
			clickCountView.AddComponent<ClickCountView> ();
			RectTransform rectTransform = clickCountView.GetComponent<RectTransform>();
			rectTransform.pivot = pivot;
			rectTransform.anchorMax = rectTransform.anchorMin = new Vector2(0, 1);
			rectTransform.anchoredPosition = anchorPosition;
		}
	}
}

