Unity Hello World Project
-------------------------

A quick start example project to be used as a reference when starting your own robotlegs-sharp project.
For more in depth documentation check the docs within the main repository [here.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/ABriefOverview.md)

Robotlegs-Sharp Code Reference
==============================

Context
-------
```csharp
public class HelloWorld : MonoBehaviour
{
    IContext context;

    public void Start()
    {
		// Creation of context, installing extensions and configuration of configs
        context = new Context ();
        context.Install<UnitySingleContextBundle> ()
            .Configure<HelloWorldConfig> ()
            .Configure (new TransformContextView (this.transform));
    }
}
```

> Read more about the [context.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Context.md)

Config
------

```csharp
public class HelloWorldConfig : IConfig
{
	// In IConfig classes you can inject values based on rules from the injector

    [Inject] public IEventCommandMap eventCommandMap;
    [Inject] public IMediatorMap mediatorMap;
    [Inject] public IInjector injector;
    [Inject] public IContext context;

    public void Configure ()
    {
		// The EventCommandMap links events to commands
        eventCommandMap.Map (ClickCountEvent.Type.INCREMENT).ToCommand<IncrementClickCounterCommand>();
		
        // Mediator map attaches Mediators to Views
		mediatorMap.Map<ButtonView> ().ToMediator<ButtonMediator> ();

		// Injector will supply a value to an interface or class when requested
        injector.Map<IClickCountModel> ().ToSingleton<ClickCountModel> ();

		// This will cause the StartApplication method to be 
        // called after all configurations and extensions have run
        context.AfterInitializing (StartApplication);
    }

    private void StartApplication()
    {
        // This is a good starting point for your application
    }
}
```

> Read more about the [configs](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Context.md#configuring), [injector](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Injector.md#injector) and [mapping commands.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Commands.md#mapping-an-event-command)

View
----
```csharp
public class ButtonView : EventView
{
    protected override void Start ()
    {
		// Before Mediation

		//  This line is important when overriding, as it triggers the code that mediates your view
        base.Start ();
      	
		// After Mediation
    }

	public void HandleButtonClicked()
    {
		// A local event dispatcher, which passes events to the mediator
        dispatcher.Dispatch(new ClickCountEvent(ClickCountEvent.Type.INCREMENT));
    }
}
```

> Read more about [unity specific views.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/platforms/Unity.md#views)

Event
-----

```csharp
public class CountUpdatedEvent : Event
{
	// Enums are used to describe the event
    // The type is also used as a key in mapping
    public enum Type
    {
        VALUE_CHANGED
    }

	// Payload data can be passed with events
    public int Count { get; protected set; }

	// All Events take a enum type
    public CountUpdatedEvent (CountUpdatedEvent.Type type, int count) : base(type)
    {
        Count = count;
    }
}
```

> Read more about [events.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/GlobalEventDispatcher.md#events)

Mediator
--------
```csharp
// Mediators are always attached to views
	public class ButtonMediator : Mediator
	{
		// The view instance can optionally be injected into the mediator
		[Inject] public ButtonView view;

		public override void Initialize ()
		{
			// Adds a callback for when the view dispatches a ClickCountEvent of type INCREMENT
			AddViewListener<ClickCountEvent>(ClickCountEvent.Type.INCREMENT, Dispatch);
			/*
			 * You can alternatively pass the event to the global event dispatcher this way:
			 * AddViewListener (ClickCountEvent.Type.INCREMENT, Dispatch);
			 */

			/*
			 * To handle events from the global event dispatcher (and potentially notifying the view)
			 * use AddContextListener passing a callback
			 * AddContextListener<CountUpdatedEvent>(CountUpdatedEvent.Type.VALUE_CHANGED, HandleCountUpdatedEvent);
			 */
		}

		private void HandleClickCountEvent(ClickCountEvent evt)
		{
			// Passes the event to the global event dispatcher triggering anything mapped to the event
			Dispatch(evt);
		}
	}
```

> Read more about [mediators.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Mediators.md#mediators)


Command
-------

```csharp
// Commands are small snippets of code that 'do things' in your application
public class IncrementClickCounterCommand : ICommand
{
    // In IConfig classes you can inject values based on rules from the injector
    [Inject] public ILogger logger;
    [Inject] public IEventDispatcher dispatcher;
    [Inject] public IClickCountModel model;

    // You can also inject the event that triggered the command to pass a payload
    [Inject] public ClickCountEvent evt;

    public void Execute ()
    {
        // Entry point into the command

        // Logger outputs to console
        logger.Info ("Command Incrementing Count");

        // We access the model from the injected value
        model.IncrementCount ();

        // Sends off an event to the global event dispatcher with a payload
        // This event can then trigger other commands and be heard from mediators
        dispatcher.Dispatch(new CountUpdatedEvent(CountUpdatedEvent.Type.VALUE_CHANGED, model.Count));

        // After execute is finished commands are disposed
    }
}
```

> Read more about [commands.](https://github.com/robotlegs-sharp/robotlegs-sharp-framework/blob/master/docs/features/Commands.md#commands)




Model
-----

```csharp
// Models store data and are peristant througout the application
public class ClickCountModel : IClickCountModel
{
    // These methods and the getter are exposed through the interface
    public int Count { get; private set; }

    public void IncrementCount ()
    {
        Count++;
    }
}
```