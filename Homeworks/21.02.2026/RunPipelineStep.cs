public class RunPipelineStep
{
    private WarehouseStep _warehouseStep1 = new();
    private PaymentStep _paymentStep = new();
    private LoggerStep _loggerStep = new();

    public RunPipelineStep()
    {
        var result = _warehouseStep1
            .Step(_paymentStep)
            .Step(_loggerStep);

        Console.Write("Type product ID: ");
        int id;

        int.TryParse(Console.ReadLine(), out id);

        Console.WriteLine(result.Process(id)); 
    }
}