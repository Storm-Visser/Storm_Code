public class BlueSpruce extends ChristmasTree
{
    private double price;

    public BlueSpruce(String typeOfChristmasTree, String productInfo) {
        super(typeOfChristmasTree, productInfo);
        this.price = 25;
    }

    public double getPrice()
    {
        return this.price;
    }
}
