namespace Interface
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}