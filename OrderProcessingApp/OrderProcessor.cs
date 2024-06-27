
using System;
using System.Diagnostics;
using System.Threading.Tasks;

//Clase OrdenProcesor que procesa las ordenes de compra
public class OrderProcessor
{
    private EmailService emailService;
    private PaymentService paymentService;
    private Dictionary<Products, int> productStock;

    //Método constructor de la clase
    public OrderProcessor(EmailService emailService, PaymentService paymentService)
    {
        this.emailService = emailService;
        this.paymentService = paymentService;

        //Inicializa el stock de prodcutos usando
        productStock = new Dictionary<Products, int>
        {
            {Products.Laptop, 10},
            {Products.Mouse, 40},
            {Products.Teclado, 12},
            {Products.Auriculares, 30},
            {Products.Pantalla, 5}

        };

    }

    //Método para procesar una orden
    public async Task ProcessOrderAsync(Order order)
    {
        try
        {
            
            await ValidateOrdersAsync(order); //Método que valida la orden
            await ProcessPaymentAsync(order.Payment); //Método que procesa el pago
            await SendConfirmationAsync(order);// Método que envia la confirmarción del pago
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    //Método para validar una orden
    private async Task ValidateOrdersAsync(Order order)
    {
        Console.WriteLine($"Validando orden {order.OrderId}.");

        await Task.Delay(5000); //Simula el tiempo que se tarda en la validación
        bool orderIsValid = order.Quantity > 0 && order.TotalAmount > 0; //Verifica que la cantidad y el monto total de la compra sean mayores a 0

        //Verifica que si haya stock del producto
        if (!productStock.ContainsKey(order.Product) || productStock[order.Product] < order.Quantity)
        {
            throw new InvalidOperationException($"No hay suficiente stock para el producto {order.Product} para procesar la orden {order.OrderId}.");
        }

        if (!orderIsValid)
        {
            throw new InvalidOperationException($"La orden {order.OrderId} es invalida.");
            
        }

        Console.WriteLine($"La orden {order.OrderId} fue validada correctamente.");
    }

    //Método para procesar el pago
    private async Task ProcessPaymentAsync(Payment payment)
    {
        Console.WriteLine($"Procesando el pago para la orden {payment.OrderId}.");

        await Task.Delay(2000); //Simula el procesamiento del pago
        bool paymentSuccess = await paymentService.ValidatePaymentAsync(payment);


        if (!paymentSuccess)
        {
            throw new InvalidOperationException($"El pago no pudo ser procesado para la orden {payment.OrderId}.");
            
        }
        
        Console.WriteLine($"El pago fue procesado correctamente para la orden {payment.OrderId}.");
    }

    //Método para enviar confirmación de la orden de compra
    private async Task SendConfirmationAsync(Order order)
    {
        Console.WriteLine($"Enviando confirmación del pedido para la orden {order.OrderId}.");

        await Task.Delay(1000); //Simula el tiempo que tarda en enviar la confirmación
        bool confirmationSent = await emailService.SendOderConfirmationEmailAsync(order);

        if(!confirmationSent)
        {
            throw new InvalidOperationException($"No pudo ser enviada la confirmación del pedido para la orden {order.OrderId}.");
                      
        }
        
        Console.WriteLine($"La confirmación del pedido {order.OrderId} fue enviada.");

      
    }
}