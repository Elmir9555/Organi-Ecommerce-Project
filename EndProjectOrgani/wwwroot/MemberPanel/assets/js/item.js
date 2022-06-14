let item = JSON.parse(localStorage.getItem("products"));


let prcs = item.map(p => p.price)


let prcss=prcs.map(a=>a.slice(1))
let prcsss=prcss.map(Number)



let tot = document.querySelector(".price").children[1];


let sum=0;
for (let i = 0; i < prcsss.length; i++) {
    
    sum+=prcsss[i];
    
}


tot.innerText = sum + ".00$"




