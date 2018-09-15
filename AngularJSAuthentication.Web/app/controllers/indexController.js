'use strict';
app.controller('indexController', ['$scope', '$rootScope', '$location', 'authService', function ($scope, $rootScope, $location, authService) {
    $scope.searchcategories = [];
    var _localCategories = localStorage.getItem("Categories");
    if (_localCategories != null && _localCategories != undefined) {
        _localCategories = JSON.parse(_localCategories);

    }
    else {
        _localCategories = [];
    }
    $scope.shoppingCart = [];
    $scope.TotalOfCartItems = 0;

    var _localCartItems = localStorage.getItem("shoppingCart");
    if (_localCartItems != null && _localCartItems != undefined) {
        _localCartItems = JSON.parse(_localCartItems);

    }
    else {
        _localCartItems = [];
    }
    $scope.shoppingCart = _localCartItems;
  
    CalculateTotal();

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

  //  $scope.$emit("CategoryID", CATID);


    $rootScope.$on("GetCategories", function () {
        $scope.GetCategories();
    });

    $rootScope.$on("AddToCart", function (event, productId, product, ID) {
        $scope.AddToCart(productId, product, ID);
    });
    $rootScope.$on("DeleteFromCart", function (event, product) {
        $scope.DeleteFromCart(product);
    });
    $rootScope.$on("CalculateCart", function (event, cart) {
        CalculateTotal(cart);
    });
    
    $scope.GetCategories = function () {

        $scope.loadallcat = false;

        $.ajax({
            url: serviceBase + '/api/Categories/GetCategories',
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                $scope.searchcategories = data;

                localStorage.setItem("Categories", JSON.stringify(data));

             

                debugger;


                $scope.loadallcat = true;

                $scope.$apply();



            },
            error: function (xhr, textStatus, errorThrown) {
                $scope.categories = [];
            }
        });
    };


    $scope.GetCart = function () {
        var authData = localStorageService.get('authorizationData');
        debugger;
        $.ajax({
            url: serviceBase + 'api/Cart/GetCart?UserName=' + authData.userName,
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                debugger;

                $scope.CurrentCartList = data;

                $scope.shoppingCart = $scope.CurrentCartList;

                for (var i = 0; i < $scope.shoppingCart.length; i++) {
                    $scope.shoppingCart[i].Quantity = 1;
                }

                console.log($scope.CurrentCartList);
                $scope.$apply();
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("into error");
            }
        });

    }

    $scope.GoToProductsWithCategoryID = function (ID) {

        debugger;
         localStorage.setItem("filterCategoryID", ID);

      //  $rootScope.$emit("CategoryID", ID);
         $location.path('/Product');

         $("#Dummylink").trigger('click');

    }


    $scope.GetProductImageGlobal = function (Path) {
        if ($.trim(Path) != "") {
            return _GlobalImagePath + "/ProductImages/" + Path;
        }
        return "../img/no-image.png";
    }

    $scope.AddToCart = function (productId, product, ID) {
        debugger;
        var authData = localStorageService.get('authorizationData');

        if (product[5] !== 0) {
            //var item = $scope.shoppingCart.filter(function (item) {
            //    if (item.ProductId === product[8]) {
            //        item.Quantity = item.Quantity + 1;
            //    }
            //    return item.ProductId === product[8];
            //})[0];
            //if (item == undefined) {
            //    $scope.CartProductsCounter++;
            //    $scope.shoppingCart.push({ ProductId: product[8], Image: product[2], Quantity: 1, ProductName: product[3], ProductQuantity: product[5], Cost: product[4], discount: 0, SupplierID: product[11] });

            //}
            Animate2Item("#" + ID + productId);

            //localStorage.setItem("shoppingCart", JSON.stringify($scope.shoppingCart));

            var cartModel = { ProductId: productId, CustomerId: -1, UserID: authData.userName };
            $.ajax({
                url: serviceBase + 'api/Cart/PostCart',
                type: 'POST',
                data: cartModel,
                dataType: 'json',
                success: function (data) {
                    debugger;
                    if (data.success == true) {
                        $scope.iconclass = "angel icon-heart";
                        $scope.$apply();
                        $scope.GetCart();
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert("into error");
                }
            });


            CheckScopeBeforeApply();
            CalculateTotal();
        }
        else {
            toastr.error("You can't Add this Item becasue it is Not Available in Stock");
        }
    };

    $scope.DeleteFromCart = function (Product) {
        for (var i = 0; i < $scope.shoppingCart.length; i++) {
            if ($scope.shoppingCart[i].ProductId == Product.ProductId) {
                $scope.shoppingCart.splice($.inArray(Product, $scope.shoppingCart), 1);
            }
        }

        //localStorage.setItem("shoppingCart", JSON.stringify($scope.shoppingCart));



        var authData = localStorageService.get('authorizationData');

        $.ajax({
            url: serviceBase + 'api/Cart/DeleteFromCart?UserName=' + authData.userName + '&id=' + Product.id,
            type: 'DELETE',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                $scope.GetCart();
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("into error");
            }
        });



        CheckScopeBeforeApply();
        CalculateTotal();

        return false;
    }

    function CalculateTotal(cart) {
        $scope.shoppingCart = cart==undefined || cart==null ?$scope.shoppingCart:cart;
        var total = 0;

        for (var i = 0; i < $scope.shoppingCart.length; i++) {
            var product = $scope.shoppingCart[i];
            total += (product.Cost * product.Quantity);
        }
        $scope.TotalOfCartItems = total;
        _globalTotal = total;
        CheckScopeBeforeApply();
    }
    if (_localCategories.length == 0) {
        $scope.GetCategories();

    }
    else {
        $scope.searchcategories = _localCategories;
    }
    $scope.authentication = authService.authentication;


    function Animate2Item(originalID) {
        $(originalID).animate_from_to('.cart', {
            pixels_per_second: 700,
            initial_css: {
                'background': 'rgb(214, 209, 216,0.5)',
                'border-radius': '100%'
            }
        });

        //$('html, body').animate({
        //    'scrollTop': $(".cart").position().top
        //},1500);
    }


    function CheckScopeBeforeApply() {
        if (!$scope.$$phase) {
            $scope.$apply();
        }
    };

}]);