
//Clase Order que representa una orden de compra
public class Order{
    
    private static int nextOrderId = 1; // Inicialización del contador de los Ids de las ordenes

    //Declaración de propiedades para la clase Order
    private int orderId;
    
    public int OrderId
    {
        get{return orderId;}
        set{ orderId = value;}
    }
    public string CustomerName {get; set;}
    public string EmailCustomer{get; set;}
    public Products Product{get; set;}
    public int Quantity {get; set;}
    public decimal TotalAmount {get; set;}
    public Payment Payment{get; set;} //Propiedad para poder crear el objeto Payment cada que se crea un objeto Order


    public Order(string customerName, string emailCustomer, Products product, int quantity, decimal totalAmount, PaymentMethod paymentMethod)
    {
        // Valida que el paymentMethod esté en el enum PaymentMethod
        if (!Enum.IsDefined(typeof(Products), product))
        {
            throw new ArgumentException($"El siguiente producto es invalido: {product}");
        }

        OrderId = nextOrderId++; // Asigna el próximo ID de pago y luego incrementa el contador
        CustomerName = customerName;
        EmailCustomer = emailCustomer;
        Product = product;
        Quantity = quantity;
        TotalAmount = totalAmount;

        //Crea el objeto Payment relacionado con la orden de compra
        Payment = new Payment(orderId, totalAmount, paymentMethod);
    }


}