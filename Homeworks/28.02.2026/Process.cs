public class Process
{ 
    public static void ProcessDecimal()
    {
        OrderBuilder<decimal> orderBuilderDecimal = new();
        Order<decimal> orderDecimal = orderBuilderDecimal
            .WithSetId(777)
            .WithPriceStep(1337)
            .Build();
        
        DiscountHandler<decimal> discountDecimal = new(1000m);
        TaxHandler<decimal>  taxDecimal = new(1.22m); // как НДС :)
        ValidationHandler<decimal> validationDecimal = new();
        discountDecimal.SetNext(taxDecimal);
        taxDecimal.SetNext(validationDecimal);
        
        discountDecimal.Handle(orderDecimal);
    }
    
    public static void ProcessDouble()
    {
        OrderBuilder<double> orderBuilderDouble = new();
        Order<double> orderDouble = orderBuilderDouble
            .WithSetId(43)
            .WithPriceStep(540)
            .Build();
        
        DiscountHandler<double> discountDouble = new(99.0);
        TaxHandler<double>  taxDouble = new(1.7);
        ValidationHandler<double> validationDouble = new();
        discountDouble.SetNext(taxDouble);
        taxDouble.SetNext(validationDouble);
        
        discountDouble.Handle(orderDouble);
    }
}