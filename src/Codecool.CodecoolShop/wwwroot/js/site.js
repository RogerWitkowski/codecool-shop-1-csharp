
async function CategoryContent(json) {
    let onClic = document.getElementById('BNTCatrgories');
    if (onClic.innerHTML == 'v') {
        onClic.innerHTML = '^';
        let div = document.getElementById('categories');
        for (item in json) {
            let button = document.createElement("button");
            button.innerHTML = json[item].category.name;
            button.value = json[item].category.name;
            button.addEventListener('click', function () {
                document.getElementById('productContainer').innerHTML = "";
                for (item in products) {
                    if (button.value == products[item].category.name) {
                        DisplayContent(products[item])
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

async function DisplayContent(data) {
    console.log(data)
    document.getElementById('productContainer').innerHTML += `<div class="col-lg-3 col-md-6">
                <div class="row p-2">
                    <div class="col-12 p-1" style="border: 1px solid #008cba; border-radius: 5px;">
                        <div class="card">
                            <img src="${data.imageUrl}" class="card-img-top rounded"/>
                            <div class="card-body">
                                <div class="p-lg-1">
                                    <p class="card-title h5 text-primary">${data.name}</p>
                                    <p class="card-title h6 text-info">Category:<b>${data.category.name}</b></p>
                                </div>
                                <div class="p-lg-1">
                                    <p>Price: <b>${data.defaultPrice.toFixed(2)} zł</b></p>
                                </div>
                            </div>
                            <div>
                                <a asp-action="Details" class="btn btn-primary form-control" asp-route-id="${data.id}">
                                    Details
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                </div>`;
    
}