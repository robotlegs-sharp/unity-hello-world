using UnityEngine;
using helloworld.controller.commands;
using helloworld.events;
using helloworld.models;
using helloworld.views;
using helloworld.views.mediators;
using robotlegs.bender.extensions.eventCommandMap.api;
using robotlegs.bender.extensions.mediatorMap.api;
using robotlegs.bender.framework.api;

namespace helloworld.config
{
	public class HelloWorldConfig : IConfig
	{
		[Inject] public IEventCommandMap eventCommandMap;
		[Inject] public IMediatorMap mediatorMap;
		[Inject] public IInjector injector;
		[Inject] public IContext context;

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
			buttonView.transform.parent = context.injector.GetInstance<Transform>();
			buttonView.AddComponent<ButtonView> ();

			CreateClickCountView(Vector2.zero, new Vector2(0, 1));
			CreateClickCountView(new Vector2(Screen.width, 0), new Vector2(1, 1));
		}

		private void CreateClickCountView(Vector2 anchorPosition, Vector2 pivot)
		{
			GameObject clickCountView = new GameObject ("Click Count view");
			clickCountView.transform.parent = context.injector.GetInstance<Transform>();
			clickCountView.AddComponent<ClickCountView> ();
			RectTransform rectTransform = clickCountView.GetComponent<RectTransform>();
			rectTransform.pivot = pivot;
			rectTransform.anchorMax = rectTransform.anchorMin = new Vector2(0, 1);
			rectTransform.anchoredPosition = anchorPosition;

		}
	}
}

