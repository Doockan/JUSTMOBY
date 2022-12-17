namespace WaterSortPuzzle.Services.LoadSceneServices
{
  public interface ILoadGameSceneService : IService
  {
    void LoadLevel(int levelNum);
    int CurrentScene { get;}
  }
}