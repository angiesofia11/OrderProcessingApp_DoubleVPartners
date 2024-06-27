// Clase Payment que representa un pago relacionado a una orden
public class Payment
{
    private static int nextPaymentId = 1; // Inicialización del contador de los Ids de los pagos

    //Declaración de propiedades de la clase Payment
    public int PaymentId {get; set;}
    public int OrderId{get; set;}
    public decimal Amount{get; set;}
    public PaymentMethod PaymentMethod{get; set;}

    public Payment( int orderId, decimal amount, PaymentMethod paymentMethod)
    {
        // Valida que el paymentMethod esté en el enum PaymentMethod
        if (!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
        {
            throw new ArgumentException($"El siguiente método de pago es invalido: {paymentMethod}");
        }

        PaymentId = nextPaymentId++; // Asigna el próximo ID de pago y luego incrementa el contador
        OrderId = orderId;
        Amount = amount;
        PaymentMethod = paymentMethod;
    }
}