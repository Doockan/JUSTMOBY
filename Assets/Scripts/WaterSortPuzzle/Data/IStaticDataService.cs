using WaterSortPuzzle.Services;
using WaterSortPuzzle.StaticData;

namespace WaterSortPuzzle.Data
{
  public interface IStaticDataService : IService
  {
    void LoadData();
    LevelStaticData ForLevel(int levelNum);
    ColorStaticData ForColor();
  }
}