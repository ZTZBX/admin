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


$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.showAdmin == true) {
            document.getElementsByClassName("main")[0].style.display = "block";
        }
        else {
            document.getElementsByClassName("main")[0].style.display = "none";
        }
    });

    $("#exit").click(function() {

        fetch(`https://admin/exit`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
            ).then(
                resp => document.getElementById("error_message").style.display = "block"   
            );
    });
    

    $("#kick_me").click(function() {

        fetch(`https://admin/serverKick`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                id: "me",
                reason: "Admin kick test"
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
            ).then(
                resp => document.getElementById("error_message").style.display = "block"   
            );
    });

});