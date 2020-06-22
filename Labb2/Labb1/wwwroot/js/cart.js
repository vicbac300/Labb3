function AddToCart(productID) {
	fetch("https://localhost:44347/api/cart/addtocart?id=" + productID)
		.then(Response => {
			console.log(response);
		});
}