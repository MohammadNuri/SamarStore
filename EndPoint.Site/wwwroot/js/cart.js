function AddCount(CartItemId) {
    window.location.replace('/cart/add?CartItemId=' + CartItemId);
}


function lowCount(CartItemId, returnUrl) {

    // Redirect to the URL with the 'returnUrl' query parameter
    window.location.replace(`/cart/LowOff?CartItemId=${CartItemId}&returnUrl=${returnUrl}`);

}
