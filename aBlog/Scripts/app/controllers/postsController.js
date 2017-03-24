var FavoriteController = function (favoriteService) {
    var button;

    var done = function () {
        button.toggleClass("btn-info").toggleClass("btn-default")
            .children().toggleClass("glyphicon-star-empty").toggleClass("glyphicon-star");
    };

    var fail = function () {

    };
    var toggleFavorite = function (e) {
        button = $(e.target);

        var postId = button.attr("data-post-id");

        if (button.hasClass("btn-default")) {
            favoriteService.createFavorite(postId, done, fail);
        } else {
            favoriteService.deleteFavorite(postId, done, fail);
        }
    };
    var init = function (container) {
        $(container).on("click", ".js-toggle-favorite", toggleFavorite);
        //$(".js-toggle-favorite").click(toggleFavorite);
    };

    



    

    return {
        init: init
    };
}(FavoriteServire);