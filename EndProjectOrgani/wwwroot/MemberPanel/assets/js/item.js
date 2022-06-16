let item = JSON.parse(localStorage.getItem("products"));


let prcs = item.map(p => p.price)


let prcss=prcs.map(a=>a.slice(1))
let prcsss=prcss.map(Number)



let tots = document.querySelector(".price").children[1];


let pricesum=0;
for (let i = 0; i < prcsss.length; i++) {

    pricesum += prcsss[i];
    
}


tots.innerText = pricesum + ".00$"




