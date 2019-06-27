namespace ServiciosRepositorio
{
    public interface IInclusion
    {
        void AddInclusion(params string[] inclusions);
        void ClearInclusions();
        string GetInclusions();
    }
}