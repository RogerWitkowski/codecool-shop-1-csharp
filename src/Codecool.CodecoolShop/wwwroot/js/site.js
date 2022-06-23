async function RefreshProducts(filter) {
    let url = "";
    if (filter == 'category') {
        let category = document.getElementById("categories").value;
        url = `/getProducts?filter=${category}&filterBy=category`;
    } else {
        let suplier = document.getElementById("supliers").value;
        url = `/getProducts?filter=${suplier}&filterBy=supplier`;
    }
    await fetch(url)
        .then(response => response.json())
        .catch(error => console.log(error))
        .then(data => DisplayContent(data))
        .catch(error => console.log(error));
        
}

async function DisplayContent(data) {
    document.getElementById("productContainer").innerHTML = "";
    for (item in data) {
        document.getElementById("productContainer").innerHTML += `<div class="col-lg-3 col-lg-3" style="display: inline-block; max-width: 350px; height: 350px; margin-bottom: 200px;">
        <div class="card" style="min-height: 533px">
            <img src="img/${data[item].Name}.jpg" style="height: 50%; width: 50%; align-self: center; padding-top: 10px">
            <div class="card-body">
                <h5 class="card-title text-center">
                    Product
                    ${parseInt(item) + 1}
                </h5>
                <h5 class="card-title">${data[item].Name}</h5>
                <p class="card-text">${data[item].Description}.</p>
                <p class="card-text">Category: ${data[item].ProductCategory.Department}</p>
                <p class="card-text">Supplier: ${data[item].Supplier.Name}</p>
                <p class="card-text text-center"><strong>Price: ${data[item].DefaultPrice.toFixed(2) + ' zł'}</strong></p>
                <span id="${data[item].Id}"><a onclick="addToCart(${data[item].Id})"  onload="addToCart(${data[item].Id})" type="button" class="btn btn-primary" style="float: bottom">Add To Cart</a></span>
            </div>
        </div>
    </div>`;
    }
}