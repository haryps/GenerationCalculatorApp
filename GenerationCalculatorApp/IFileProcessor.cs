namespace GenerationCalculatorApp
{
    public interface IFileProcessor
    {
        public TData Parse<TData>(string filePath) where TData : class;
        void Write<TData>(string filePath, TData data);
    }
}