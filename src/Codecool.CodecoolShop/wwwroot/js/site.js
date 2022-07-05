
async function CategoryContent(json) {
    let onClic = document.getElementById('BNTCatrgories');
    if (onClic.innerHTML == 'v') {
        onClic.innerHTML = '^';
        let div = document.getElementById('categories');
        for (item in json) {
            let button = document.createElement("button");
            button.innerHTML = json[item].name;
            button.value = json[item].name;
            button.addEventListener('click', function () {
                document.getElementById('productContainer').innerHTML = "";
                for (item in products) {
                    if (button.value == products[item].productCategory.name) {
                        DisplayContent(products[item], 'productContainer')
                    }
                }
            })
            div.appendChild(button);
        }
    } else {
        onClic.innerHTML = 'v';
        let div = document.getElementById('categories');
        div.innerHTML = '';
    }
}

async function SupplayerContent(json) {
    let onClic = document.getElementById('BNTSupplayer');
    if (onClic.innerHTML == 'v') {
        onClic.innerHTML = '^';
        let div = document.getElementById('supplayer');
        for (item in json) {
            let button = document.createElement("button");
            button.innerHTML = json[item].name;
            button.value = json[item].name;
            button.addEventListener('click', function () {
                document.getElementById('productContainer').innerHTML = "";
                for (item in products) {
                    if (button.value == products[item].supplier.name) {
                        DisplayContent(products[item], 'productContainer');
                    }
                }
            })
            div.appendChild(button);
        }
    } else {
        onClic.innerHTML = 'v';
        let div = document.getElementById('supplayer');
        div.innerHTML = '';
    }
}



async function DisplayContent(data,contener) {
        document.getElementById(contener).innerHTML += `<div class="col-lg-3 col-lg-3" style="display: inline-block; max-width: 350px; height: 350px; margin-bottom: 200px;">
        <div class="card" style="min-height: 533px">
            <img src="img/${data.name}.jpg" style="height: 50%; width: 50%; align-self: center; padding-top: 10px">
            <div class="card-body">
                <h5 class="card-title">${data.name}</h5>
                <p class="card-text">${data.description}.</p>
                <p class="card-text">Category: ${data.productCategory.department}</p>
                <p class="card-text">Supplier: ${data.supplier.name}</p>
                <p class="card-text text-center"><strong>Price: ${data.defaultPrice.toFixed(2) + ' zł'}</strong></p>
                <span id="${data.id}"><a onclick="addToCart(${data.id})"  onload="addToCart(${data.id})" type="button" class="btn btn-primary" style="float: bottom">Add To Cart</a></span>
            </div>
        </div>
    </div>`;
    
}