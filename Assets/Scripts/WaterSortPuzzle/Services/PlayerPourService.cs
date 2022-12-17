using DG.Tweening;
using WaterSortPuzzle.Models;
using WaterSortPuzzle.Services.Factory;

namespace WaterSortPuzzle.Services
{
  public class PlayerPourService : IPlayerPourService
  {
    private readonly IGameFactoryService _factory;
    private readonly IAnimationService _animation;
    private readonly TweenCallback _goPour;
    private readonly TweenCallback _onComplete;
    
    private Flask _firstFlask;
    private Flask _secondFlask;
    private bool _isPouring;


    public PlayerPourService(IGameFactoryService factory, IAnimationService animation)
    {
      _factory = factory;
      _animation = animation;
      _goPour = Pour;
      _onComplete = FinishedPouring;
    }

    public void SubscribeAllFlask()
    {
      foreach (var flask in _factory.InitializedFlasks)
        flask.OnClick += PressingOnFlask;
    }

    private void PressingOnFlask(Flask flask)
    {
      if (_isPouring) return;
      
      if (_firstFlask == null) { Select(flask); return; }

      if (_firstFlask == flask) { Unselect(flask); return; }

      _secondFlask = flask;
      
      if (!CanPourOut(_firstFlask, _secondFlask)) { Unselect(_firstFlask); return; }

      _isPouring = true;
      _animation.PourAnimation(_firstFlask.View.transform, _secondFlask.View.transform, onReadyToPour: _goPour, _onComplete);
    }

    private void Pour()
    {
      _firstFlask.PourOut(_secondFlask, _firstFlask.IdenticalColors());
      _secondFlask = null;
      _firstFlask = null;
    }

    private void FinishedPouring() => 
      _isPouring = false;

    private bool CanPourOut(Flask firstFlask, Flask secondFlask)
    {
      if (firstFlask.IsEmpty()) return false;
      if (secondFlask.IsEmpty()) return true;
      if (secondFlask.IsFull()) return false;
      return firstFlask.TopColor() == secondFlask.TopColor();
    }

    private void Select(Flask flask)
    {
      _firstFlask = flask;
      _animation.SelectAnimation(flask.View.transform);
    }

    private void Unselect(Flask flask)
    {
      _firstFlask = null;
      _animation.UnselectAnimation(flask.View.transform);
    }
  }
}