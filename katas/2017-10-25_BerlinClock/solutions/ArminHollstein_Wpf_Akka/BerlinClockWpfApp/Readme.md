NUGET Pakete
AKKA.NET
AKKA.DI.AUTOFAC

[AKKA.Net Doku](http://getakka.net/articles/actors/testing-actor-systems.html)



private SolidColorBrush _minute1Toggle;  
private readonly IActorRef _minute1Actor;  
--CTOR
_minute1Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>( 1, (Action)UpdateMinute1ToOn, (Action)UpdateMinute1ToOff));  
_publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute1Actor));

public SolidColorBrush Minute1Toggle
{
    get => _minute1Toggle;
    set
    {
        _minute1Toggle = value;
        OnPropertyChanged();
    }
}

public void UpdateMinute1ToOn()
{
    Minute1Toggle = minuteOnColor;
}
public void UpdateMinute1ToOff()
{
    Minute1Toggle = minuteOffColor;
}