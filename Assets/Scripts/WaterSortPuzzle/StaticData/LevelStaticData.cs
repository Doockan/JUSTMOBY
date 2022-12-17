using UnityEngine;

namespace WaterSortPuzzle.StaticData
{
  [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
  public class LevelStaticData : ScriptableObject
  {
    [SerializeField] private int _levelNum;
    [Range(4, 8)] [SerializeField] private int _flask;
    
    [SerializeField] private int _repeatedSearches;

    [Header("Random Settings - 1 Step")] 
    [SerializeField] private float _oneStepPercentageForTwo;
    [SerializeField] private float _oneStepPercentageForOne;

    [Header("Random Settings - 2 Step")] 
    [SerializeField] private float _twoStepPercentageForOne;


    public int LevelNum => _levelNum;
    public int Flask => _flask;

    public int RepeatedSearches => _repeatedSearches;

    public float OneStepPercentageForTwo => _oneStepPercentageForTwo;
    public float OneStepPercentageForOne => _oneStepPercentageForOne;
    
    public float TwoStepPercentageForOne => _twoStepPercentageForOne;
  }

}