using DG.Tweening;
using UnityEngine;

namespace WaterSortPuzzle.Services
{
  public class AnimationService : IAnimationService
  {
    public void SelectAnimation(Transform flask) => 
      flask.DOMove(flask.position + new Vector3(0, 0.5f, 0), 0.2f);

    public void UnselectAnimation(Transform flask) => 
      flask.DOMove(flask.position + new Vector3(0, -0.5f, 0), 0.2f);

    public void PourAnimation(Transform firstFlask, Transform secondFlask,
      TweenCallback onReadyToPour = null, TweenCallback onComplete = null)
    {
      var starPosition = firstFlask.position;
      var left = firstFlask.position.x < secondFlask.position.x;

      DOTween.Sequence()
        .Append(firstFlask.DOMove(secondFlask.position + new Vector3(left ? -0.6f : 0.6f, 0.6f, -1), 0.5f))
        .Append(firstFlask.DORotateQuaternion(Quaternion.Euler(0, 0, left ? -100 : 100), 1))
        .AppendCallback(onReadyToPour)
        .Append(firstFlask.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1))
        .Append(firstFlask.DOMove(starPosition + new Vector3(0, -0.5f, 0), 0.5f))
        .SetEase(Ease.InOutSine)
        .OnComplete(onComplete);
    }
  }
}