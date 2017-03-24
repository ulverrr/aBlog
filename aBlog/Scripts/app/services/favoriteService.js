var FavoriteServire = function () {
    var createFavorite = function (postId, done, fail) {
        $.post("/api/favoritepost", { postId: postId })
            .done(done)
            .fail(fail);
    };

    var deleteFavorite = function (postId, done, fail) {
        $.ajax({
            url: "/api/favoritepost/" + postId,
            method: "DELETE"
        }).done(done)
            .fail(fail);
    };

    return {
        createFavorite: createFavorite,
        deleteFavorite: deleteFavorite
    };
}();