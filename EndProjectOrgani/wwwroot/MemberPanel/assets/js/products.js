import {favoriCount,basketCount,getCountheart,dropdowns,searchfilterdropdown,addproducts,addproductsfav} from "./common.js"

//header start ALL CATEGORIES dropdown

 dropdowns();

//header end ALL CATEGORIES dropdown


//start searchfilter
searchfilterdropdown();
//end searchfilter


$(document).ready(function () {
    $("#default").click(function () {
        $(".sort-content").toggle();

        if ($(".sort-content").css("display") == "block") {
            $("#icon").css("transform", "rotate(-180deg)")
            $("#icon").css("transition", "all 0.5s")

        }
        else {
            $("#icon").css("transform", "rotate(0deg)")
        }
    });
});



//favoriproduct count 
let heartcount=document.querySelector(".heart-count")
favoriCount(heartcount)
//favoriproduct count 

//Basket count 
let basketcount=document.querySelector(".basket-count")
basketCount(basketcount)
//Basket count 


//rightcorner favoriproduct count 
let countfavo=document.querySelector(".product-count strong")
countfavo.innerText=JSON.parse(localStorage.getItem("FavoriProduct")).length
//rightcorner favoriproduct count


addproducts();
addproductsfav();
