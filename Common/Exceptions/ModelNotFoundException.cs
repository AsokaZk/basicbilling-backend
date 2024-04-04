namespace Common.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(int id, string model)
            : base($"{model} with id [{id}] not found")
        {
        }
    }
}
