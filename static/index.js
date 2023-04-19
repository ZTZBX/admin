window.players = [];

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

function changeCoords(new_coords) {
    coords = JSON.parse(new_coords["coords"])
    document.getElementById("z_coord").innerText = coords.z
    document.getElementById("x_coord").innerText = coords.x
    document.getElementById("y_coord").innerText = coords.y
}

function generatePlayerHtml(username)
{
    var players_base = ' \
    <div class="player" id="player_'+username+'"> \
    <p>'+username+'</p> \
    <a href="#" class="btn mt-4">ban</a> \
    <a href="#" class="btn mt-4">kick</a> \
    <a href="#" class="btn mt-4">tpme</a> \
    <a href="#" class="btn mt-4">tp</a> \
    </div>';

    return players_base;
}

function filterPlayers() {
    var input =  document.getElementById('playersFilter');
    filter = input.value.toUpperCase();

    for (var i in window.players)
    {
        if (!window.players[i].toUpperCase().includes(filter))
        {
            document.getElementById("player_"+window.players[i]).style.display = "none";
        } 
        else
        {
            document.getElementById("player_"+window.players[i]).style.display = "block";
        }
    }

}

function addPlayers(players) {

    document.getElementById("players_menu").innerHTML = '<input type="text" id="playersFilter" onkeyup="filterPlayers()" placeholder="Username Filter" style="width: 90%; margin-bottom: 1rem; position: sticky;top: 0;" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm">';
    
    window.players = JSON.parse(players["data"]).players;

    for (var i in window.players)
    { 
        document.getElementById("players_menu").innerHTML += generatePlayerHtml(window.players[i]);
    }
    
}

$(function () {

    $("#getplayers").click(function () {
        fetch(`https://admin/getplayers`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(success => addPlayers(success));
    });

    window.addEventListener('message', function (event) {
        var item = event.data;

        if (item.showAdmin == true) {

            fetch(`https://admin/coords`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => changeCoords(success));

            document.getElementsByClassName("main")[0].style.display = "block";

        }
        else {
            document.getElementsByClassName("main")[0].style.display = "none";
        }
    });

    $("#exit").click(function () {

        fetch(`https://admin/exit`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json())
    });


    $("#kick_me").click(function () {

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


    $("#die").click(function () {

        fetch(`https://admin/kill`, {
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

    $("#noclip").click(function () {

        fetch(`https://admin/noclip`, {
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


    $("#invincible").click(function () {

        fetch(`https://admin/invincible`, {
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



});