package adpaterpatternexample;

import adpaterpatternexample.Paypal.PayPalAdapter;
import adpaterpatternexample.Paypal.PayPalGateway;
import adpaterpatternexample.Square.SquareAdapter;
import adpaterpatternexample.Square.SquareGateway;
import adpaterpatternexample.Stripe.StripeAdapter;
import adpaterpatternexample.Stripe.StripeGateway;

public class AdapterPatternTest {
    public static void main(String[] args) {
        // PayPal Payment
        PaymentProcessor paypalProcessor = new PayPalAdapter(new PayPalGateway());
        paypalProcessor.processPayment(100.50);

        // Stripe Payment
        PaymentProcessor stripeProcessor = new StripeAdapter(new StripeGateway());
        stripeProcessor.processPayment(250.75);

        // Square Payment
        PaymentProcessor squareProcessor = new SquareAdapter(new SquareGateway());
        squareProcessor.processPayment(500.00);
    }
}