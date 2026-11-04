// FAVORITES FUNCTION

document.addEventListener("DOMContentLoaded", function () {

    let favorites = JSON.parse(localStorage.getItem("favorites")) || [];

    function updateButtons() {
        document.querySelectorAll(".favorite-button").forEach(button => {
            let id = button.dataset.productId;

            if (favorites.includes(id)) {
                button.classList.add("active");
                button.textContent = "♥";
            } else {
                button.classList.remove("active");
                button.textContent = "♡";
            }
        });
    }

    updateButtons();

    document.querySelectorAll(".favorite-button").forEach(button => {
        button.addEventListener("click", function () {

            let id = this.dataset.productId;

            if (favorites.includes(id)) {
                favorites = favorites.filter(item => item !== id);
            } else {
                favorites.push(id);
            }

            localStorage.setItem("favorites", JSON.stringify(favorites));

            updateButtons();
        });
    });

});