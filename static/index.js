function showUtl() {
    var target = document.getElementById("utilities_menu");
    var other_pl = document.getElementById("players_menu");

    if (other_pl.style.display !== "none") {
        other_pl.style.display = "none";
    }

    if (target.style.display === "none") {
        target.style.display = "block";
    } 
}

function showPlayers() {
    var target = document.getElementById("players_menu");
    var other_pl = document.getElementById("utilities_menu");

    if (other_pl.style.display !== "none") {
        other_pl.style.display = "none";
    }
    if (target.style.display === "none") {
        target.style.display = "block";
    }
}