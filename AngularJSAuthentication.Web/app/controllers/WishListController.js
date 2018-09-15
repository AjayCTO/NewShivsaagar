'use strict';
app.controller('WishListController', ['$scope', '$location','localStorageService','authService', function ($scope, $location,localStorageService, authService) {

    $scope.CurrentWishList = [];
    $scope.CurrentWishList.length;
    $scope.GetProductImage = function (Path) {
        if ($.trim(Path) != "") {
            return _GlobalImagePath + "/ProductImages/" + Path;
        }
        return "../img/no-image.png";
    }

    $scope.addtocart = function (productId, product) {
        debugger;
        alert("call from wish list by me");


        var item = $scope.AllCartItems.filter(function (item) {
            if (item.ProductId === product.ProductId) {
                item.Quantity = item.Quantity + 1;
            }
            return item.ProductId === product.ProductId;
        })[0];

        if (item == undefined) {
            $scope.CartProductsCounter++;
            //$('html, body').animate({
            //    'scrollTop': $(".cart_anchor").position().top
            //});
            //var itemImg = $("#pid" + productId).parent().find('img').eq(0);
            $scope.AllCartItems.push({ ProductId: product.ProductId, Image: product.Image, Quantity: 1, ProductName: product.ProductName, Cost: product.ProductPrice, discount: 0 });



        }
        CartToCookieService.setCookieData($scope.AllCartItems);
        $rootScope.$emit("CallGetCookieData", {});
        $scope.RemoveFromwishList(product.Id);
    };


    function init() {
        $scope.GetWishList();
    }
    $scope.GetWishList = function () {
        var authData = localStorageService.get('authorizationData');       

        debugger;
        $.ajax({
            url: serviceBase + 'api/CustomerWishlist/GetWishLists?UserName=' + authData.userName,
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                debugger;
                console.log(data);
                
                $scope.CurrentWishList = data;
            
                console.log($scope.CurrentWishList);
                $scope.$apply();
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("into error");
            }
        });

    }

    $scope.RemoveFromwishList = function (ID) {
        debugger
        $.ajax({
            url: serviceBase + 'api/WishlistDelete/DeleteWishList?id=' + ID,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                debugger;
                if (data.success == true) {
                    $scope.GetWishList();

                }
            },
            error: function (data) {
                alert("into error");
            }
        });
    };



    init();
}]);