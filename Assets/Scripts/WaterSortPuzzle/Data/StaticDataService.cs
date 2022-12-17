using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WaterSortPuzzle.StaticData;

namespace WaterSortPuzzle.Data
{
  public class StaticDataService : IStaticDataService
  {
    private const string StaticDataLevelsPath = "StaticData/Levels";
    private const string StaticDataColorsPath = "StaticData/ColorData";

    private Dictionary<int, LevelStaticData> _levels;
    private ColorStaticData _colors;


    public void LoadData()
    {
      _levels = Resources
        .LoadAll<LevelStaticData>(StaticDataLevelsPath)
        .ToDictionary(x => x.LevelNum, x => x);

      _colors = Resources.Load<ColorStaticData>(StaticDataColorsPath);
    }


    public LevelStaticData ForLevel(int levelNum) =>
      _levels.TryGetValue(levelNum, out LevelStaticData levelStaticData)
        ? levelStaticData
        : null;

    public ColorStaticData ForColor() => _colors;
  }
}