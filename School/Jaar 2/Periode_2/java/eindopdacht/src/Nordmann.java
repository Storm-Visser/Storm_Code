public class Nordmann extends ChristmasTree
{

    private double price;
    public Nordmann(String typeOfChristmasTree, String productInfo) {
        super(typeOfChristmasTree, productInfo);
        this.price = 30;
    }

    public double getPrice()
    {
        return this.price;
    }
}
