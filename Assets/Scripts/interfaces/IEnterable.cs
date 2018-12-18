using System;

public interface IEnterable
{
    event Action<IVisibilityBehaviour> Entered;
}
