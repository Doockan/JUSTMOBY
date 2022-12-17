using DG.Tweening;
using UnityEngine;

namespace WaterSortPuzzle.Services
{
  public interface IAnimationService : IService
  {
    void SelectAnimation(Transform flask);
    void UnselectAnimation(Transform flask);
    void PourAnimation(Transform firstFlask, Transform secondFlask,
      TweenCallback onReadyToPour = null, TweenCallback onComplete = null);
  }
}