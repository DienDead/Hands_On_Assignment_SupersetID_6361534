package adpaterpatternexample.Square;

import adpaterpatternexample.PaymentProcessor;

// Adapter for Square
public class SquareAdapter implements PaymentProcessor {
    private SquareGateway squareGateway;

    public SquareAdapter(SquareGateway squareGateway) {
        this.squareGateway = squareGateway;
    }

    @Override
    public void processPayment(double amount) {
        squareGateway.executePayment(amount);
    }
}