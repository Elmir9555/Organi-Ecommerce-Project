import {getCount} from "./common.js"
import {favoriCount,basketCount,getCountheart,dropdowns,searchfilterdropdown} from "./common.js"

//header start ALL CATEGORIES dropdown
dropdowns();
//header end ALL CATEGORIES dropdown


//start searchfilter
searchfilterdropdown();
//end searchfilter



//basket-start
let cart=document.querySelector(".cart .container")
let removeall=document.querySelector(".all-remove button")
removeall.addEventListener("click",function(e){
  localStorage.removeItem("products")
  window.location.reload();
})

let productss=[];
if (JSON.parse(localStorage.getItem("products")!=null)) {
   productss= JSON.parse(localStorage.getItem("products"))
 
   
   
}

ShowBasket();
function ShowBasket(){
  
  for (const prduct of productss) {
    let pricecount=prduct.price.replace('$','')
    let countt=document.querySelector(".cnt")

  
   
    
    cart.innerHTML+=` 
    <div class="products-cart">
    <div class="image-name">
    <div class="img">
        <img src="${prduct.image}" style="width: 100%;height: 100%;"alt="">
    </div>
    <div class="names">
        ${prduct.name}
    </div>
  </div>
  <div class="value-price-count-total">
    <div class="price-value">
       ${prduct.price}
    </div>
    <div class="count-price">
        <span class="minus">
            -
        </span>
  
        <span  class="cnt">
         ${prduct.count}
        </span>
        <span class="plus">
            +
        </span>
    </div>
    <div class="total-value">
    $${pricecount*prduct.count}
    </div>
    <div class="x">
        <i class="fas fa-times"></i>
    </div>
  </div>
  </div>
    `
   
    
  

  }
}

//remove cards localstorage
cart.addEventListener("click",deletecard)

function deletecard(e){
 if (e.target.className==="fas fa-times") {
  
   e.target.parentElement.parentElement.parentElement.remove();
   deletefromstorage(e.target.parentElement.parentElement.parentElement.children[0].children[1].innerText);

 }

}

function deletefromstorage(deleteitem) {
  
 let produt= JSON.parse(localStorage.getItem("products"));
 produt.forEach(function(pro,index){
   if(pro.name===deleteitem){
    // produt.splice(index,1)
    console.log("salamm");
   }
  console.log(pro.name);
 })

 localStorage.setItem("products", JSON.stringify(produt))

}


//remove cards localstorage






let heartcount=document.querySelector(".heart-count")
favoriCount(heartcount)


let basketcount=document.querySelector(".basket-count")
basketCount(basketcount)


//increase count
$(document).on("click",".plus",function(e){
  
     var count=Number(e.target.parentElement.children[1].innerText)
    count++;
    e.target.parentElement.children[1].innerText=count;

  //let getlocal=JSON.parse(localStorage.getItem("products"));
  //console.log(getlocal);
  //let getcount=getlocal.map(m=>m.count)
  
  //let get=getcount[0]
  //localStorage.setItem("products", JSON.stringify(count+=1))


  
  
  



 

})

$(document).on("click",".minus",function(e){
  var count=Number(e.target.parentElement.children[1].innerText)
  if(count==1){
    count=1;
  }
  else{
    count--;
    e.target.parentElement.children[1].innerText=count
  }


})
//increase count


//end-basket

//subtotal price

let total=document.querySelector(".subtotal-price .price")
let totall=document.querySelector(".total-price .price")

let price=JSON.parse(localStorage.getItem("products"))
let prices=price.map(m=>m.price)
let pricess=prices.map(s=>s.slice(1))

var array = pricess.map(Number);
let sum=0;
for (let i = 0; i < array.length; i++) {
 sum+=array[i]

}

total.innerText=sum+ ".00 $"
totall.innerText=sum+ ".00 $"






//subtotal price

