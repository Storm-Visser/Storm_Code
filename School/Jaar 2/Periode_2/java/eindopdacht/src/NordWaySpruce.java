public class NordWaySpruce extends ChristmasTree
{
    private double price;

    public NordWaySpruce(String typeOfChristmasTree, String productInfo) {
        super(typeOfChristmasTree, productInfo);
        this.price = 20;
    }

    private double GetPrice()
    {
        return this.price;
    }
}
