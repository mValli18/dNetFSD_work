function Product()
{
    var Product={
        Name : "Pencil",
        cost : 500,
        Quantity :2
    }
    return(
        <div>
            Product Name : {Product.Name}
            <br>
            Product Name : {Product.cost}
            </br>
        </div>
    )
}
export default Product;