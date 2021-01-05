public class ChristmasBall
{
    private Colors color;
    private int size;
    private double price;
    private String productInfo;

    public ChristmasBall(Colors color, int size, String productInfo) {
        this.color = color;
        this.size = size;
        this.price = 0;
        this.productInfo = productInfo;
    }

    public Colors getColor() {
        return color;
    }

    public void setColor(Colors color) {
        this.color = color;
    }

    public int getSize() {
        return size;
    }

    public void setSize(int size) {
        this.size = size;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getProductInfo() {
        return productInfo;
    }

    public void setProductInfo(String productInfo) {
        this.productInfo = productInfo;
    }

    public double calcPrice()
    {
        return this.price;
    }
}
