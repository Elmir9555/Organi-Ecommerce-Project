
//header start ALL CATEGORIES dropdown

$(document).ready(function () {

    $(".dropbtns").click(function () {
        $("#myDropdown").toggle(1000);
    });

});

window.onclick = function (event) {
    if (!event.target.matches('.dropbtns')) {
        var dropdowns = document.getElementsByClassName("dropdown-contents");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}
//header end ALL CATEGORIES dropdown



//start searchfilterdropdown

$(document).ready(function () {

    $("#all-categ").click(function () {
        $(".dropdown-content-cate").toggle(800);

    })
});
//end searchfilterdropdown

//tab-menu

$(document).ready(function(){
  $("span").click(function(){
    $(".active").removeClass("active");
    $(this).addClass("active");
  })
})

let btn=document.querySelectorAll(".center span")
let content=document.querySelectorAll(".tab-menu .description")

btn.forEach(btns=>{
  btns.addEventListener("click",function(){

    
    content.forEach(contnt=>{
      if(this.getAttribute("data-id")!=contnt.getAttribute("data-id")){
        contnt.classList.add("d-none");
      }
      else{
        contnt.classList.remove("d-none");
      }
    })
   
  })
})
//tab-menu


//increase count
let minus=document.querySelector(".minus");
let plus=document.querySelector(".plus");
let i=document.querySelector(".cnt");
let count = 0;
i.innerText=count;

minus.addEventListener("click",function(){
  if(count==0){
    i.innerText=0;
  }
  else{
    count--;
    i.innerText=count;
  }
})

plus.addEventListener("click",function(){
  count++;
  i.innerText=count;

})
//increase count


//BasketFavoriCount

let heartcount = document.querySelector(".heart-count")
favoriCount(heartcount)

function favoriCount(sum) {
    sum.innerText = JSON.parse(localStorage.getItem("FavoriProduct")).length
}





let basketcount = document.querySelector(".basket-count")
basketCount(basketcount)

function basketCount(sum) {
    sum.innerText = JSON.parse(localStorage.getItem("products")).length
}
//BasketFavoriCount

//Add Basket

let addcartproduct=document.querySelector(".addbtn button")

addcartproduct.addEventListener("click",addbasket)

function addbasket(){

  if (JSON.parse(localStorage.getItem("products") == null)) {
    localStorage.setItem("products", JSON.stringify([]));
  }

  let productList = JSON.parse(localStorage.getItem("products"))
 let productname= this.parentElement.parentElement.parentElement.children[0].innerText;
 let productprice=this.parentElement.parentElement.parentElement.children[2].innerText;
 let productimg=this.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].children[0].getAttribute("src")
 let productid=this.parentElement.parentElement.parentElement.parentElement.parentElement.children[0].children[0].getAttribute("data-id")

 let existproduct=productList.find(m=>m.id)

 if(existproduct==undefined){
  productList.push({
    id: productid,
    image: productimg,
    name: productname,
    price: productprice,
    count: 1
  });
  
  alert("Product Added Success!")
 }
 else{
  alert("You have added this Product to your Cart,Please check your basket")
 }


localStorage.setItem("products", JSON.stringify(productList))
}

//Add Basket





