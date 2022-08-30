namespace Monday.Client.Requests
{
    public interface IMondayRequest
    {
        bool CalculateComplexity { get; set; }
        bool ProcessQuery { get; set; }
    }

    public interface IMondayResult
    {
        int? Complexity { get; }
    }

    public abstract class MondayResult : IMondayResult
    {
        public int? Complexity { get; } = null;
    }

    public abstract class MondayRequest : IMondayRequest
    {
        public bool CalculateComplexity { get; set; } = false;
        public bool ProcessQuery { get; set; } = true;
    }
}
